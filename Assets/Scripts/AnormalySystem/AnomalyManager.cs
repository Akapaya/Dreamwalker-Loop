using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [SerializeField] private List<IAnomaly> _anomalies = new List<IAnomaly>();

    #region Start Methods
    private void Start()
    {
        _anomalies.AddRange(this.gameObject.GetComponentsInChildren<IAnomaly>());
    }
    #endregion

    #region Process Anomaly
    [ContextMenu("Activate Anomaly")]
    public void StartAnomaly()
    {
        foreach (var item in _anomalies)
        {
            item.OnActivateAnomaly();
        }
    }

    [ContextMenu("Deactivate Anomaly")]
    public void StopAnomaly()
    {
        foreach (var item in _anomalies)
        {
            item.OnDeactivateAnomaly();
        }
    }
    #endregion
}
