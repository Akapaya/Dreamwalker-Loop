using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnomalySystem : MonoBehaviour
{
    [SerializeField] private List<AnomalyManager> anomalyManagersList = new List<AnomalyManager>();
    private Queue<AnomalyManager> anomalyManagersQueue = new Queue<AnomalyManager>();
    private AnomalyManager actualAnomaly;

    [SerializeField]  private AnomalyManager finalAnomaly;
    [SerializeField]  private AnomalyManager secretAnomaly;

    public UnityEvent WrongExit = new UnityEvent();

    private void Start()
    {
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
            actualAnomaly = null;
        }
    }

    public void ActivateAnomaly()
    {
        if (CheckIfEndAnomaliesQueue() == false)
        {
            if (Random.Range(0, 101) <= 50)
            {
                actualAnomaly = anomalyManagersQueue.Dequeue();
                actualAnomaly.StartAnomaly();
                Debug.Log(anomalyManagersQueue.Count);
            }
        }
    }

    public bool CheckIfEndAnomaliesQueue()
    {
        if (anomalyManagersQueue.Count <=0)
        {
            ActivateFinalRoom();
            return true;
        }

        if (GameManager.CheckIfGetAllPagesHandle.Invoke())
        {
            ActivateFinalRoom();
            Invoke("ActivateSecretRoom", 5f);
            return true;
        }

        return false;
    }

    private void ActivateFinalRoom()
    {
        finalAnomaly.StartAnomaly();
    }

    private void ActivateSecretRoom()
    {
        secretAnomaly.StartAnomaly();
    }

    public void CheckBlinkEyeExit()
    {
        if(actualAnomaly == null)
        {
            WrongExit.Invoke();
        }
    }

    public void CheckDoorExit()
    {
        if (actualAnomaly != null)
        {
            WrongExit.Invoke();
        }
    }
}