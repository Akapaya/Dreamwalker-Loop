using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalySystem : MonoBehaviour
{
    [SerializeField] private List<AnomalyManager> anomalyManagersList = new List<AnomalyManager>();
    private Queue<AnomalyManager> anomalyManagersQueue = new Queue<AnomalyManager>();
    private AnomalyManager actualAnomaly;

    private void Start()
    {
        // Aleatorize a ordem da lista
        System.Random rng = new System.Random();
        int n = anomalyManagersList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            AnomalyManager value = anomalyManagersList[k];
            anomalyManagersList[k] = anomalyManagersList[n];
            anomalyManagersList[n] = value;
        }

        // Coloque os elementos aleatorizados na fila
        foreach (AnomalyManager manager in anomalyManagersList)
        {
            anomalyManagersQueue.Enqueue(manager);
        }
    }

    public void DeactiveAnomaly()
    {
        if(actualAnomaly != null)
        {
            actualAnomaly.StopAnomaly();
        }
    }

    public void ActivateAnomaly()
    {
        if (Random.Range(0, 101) <= 50)
        {
            actualAnomaly = anomalyManagersQueue.Dequeue();
            actualAnomaly.StartAnomaly();
        }
    }
}