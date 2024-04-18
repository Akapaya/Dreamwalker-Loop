using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [SerializeField] private List<IAnomaly> anomalies = new List<IAnomaly>();

    private void Start()
    {
        anomalies.AddRange(this.gameObject.GetComponentsInChildren<IAnomaly>());
    }

    [ContextMenu("Activate Anomaly")]
    public void StartAnomaly()
    {
        foreach (var item in anomalies)
        {
            item.OnActivateAnomaly();
        }
    }

    [ContextMenu("Deactivate Anomaly")]
    public void StopAnomaly()
    {
        foreach (var item in anomalies)
        {
            item.OnDeactivateAnomaly();
        }
    }
}
