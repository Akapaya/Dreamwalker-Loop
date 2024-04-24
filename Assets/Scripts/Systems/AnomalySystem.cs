using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnomalySystem : MonoBehaviour
{
    [SerializeField] private List<AnomalyManager> _anomalyManagersList = new List<AnomalyManager>();
    private Queue<AnomalyManager> _anomalyManagersQueue = new Queue<AnomalyManager>();
    private AnomalyManager _actualAnomaly;

    [SerializeField]  private AnomalyManager _finalAnomaly;
    [SerializeField]  private AnomalyManager _secretAnomaly;

    #region Unity Events
    public UnityEvent WrongExit = new UnityEvent();
    #endregion

    #region Start Methods
    private void Start()
    {
        System.Random rng = new System.Random();
        int n = _anomalyManagersList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            AnomalyManager value = _anomalyManagersList[k];
            _anomalyManagersList[k] = _anomalyManagersList[n];
            _anomalyManagersList[n] = value;
        }

        foreach (AnomalyManager manager in _anomalyManagersList)
        {
            _anomalyManagersQueue.Enqueue(manager);
        }
    }
    #endregion

    #region Active and Deactive Anomaly
    public void DeactiveAnomaly()
    {
        if(_actualAnomaly != null)
        {
            _actualAnomaly.StopAnomaly();
            _actualAnomaly = null;
        }
    }

    public void ActivateAnomaly()
    {
        if (CheckIfEndAnomaliesQueue() == false)
        {
            if (Random.Range(0, 101) <= 50)
            {
                _actualAnomaly = _anomalyManagersQueue.Dequeue();
                _actualAnomaly.StartAnomaly();
                Debug.Log(_anomalyManagersQueue.Count);
            }
        }
    }
    #endregion

    #region Check Methods
    public bool CheckIfEndAnomaliesQueue()
    {
        if (_anomalyManagersQueue.Count <=0)
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

    public void CheckBlinkEyeExit()
    {
        if (_actualAnomaly == null)
        {
            WrongExit.Invoke();
        }
    }

    public void CheckDoorExit()
    {
        if (_actualAnomaly != null)
        {
            WrongExit.Invoke();
        }
    }
    #endregion

    #region Secrets Rooms Anomalies
    private void ActivateFinalRoom()
    {
        _finalAnomaly.StartAnomaly();
    }

    private void ActivateSecretRoom()
    {
        _secretAnomaly.StartAnomaly();
    }
    #endregion
}