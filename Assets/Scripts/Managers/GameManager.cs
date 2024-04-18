using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int _collectedPagesCount = 0;
    private int _maxPagesCount = 5;

    [SerializeField] private PagesCountManager PagesCountManager;
    [SerializeField] private PlayerRespawnManager PlayerRespawnManager;

    #region UnityEvents
    public UnityEvent<int> SetMaxPagesCount = new UnityEvent<int>();
    #endregion

    #region Start Methods
    private void Start()
    {
        SetMaxPagesCount.Invoke(_maxPagesCount);
    }
    #endregion

    #region Collection Pages Methods
    [ContextMenu("Collected Page")]
    public void PageCollected()
    {

        _collectedPagesCount++;       

        PagesCountManager.UpdatePagesCount(_collectedPagesCount);
    }

    [ContextMenu("Reset Pages Count")]
    public void ResetPagesCount()
    {
        _collectedPagesCount = 0;

        PagesCountManager.UpdatePagesCount(_collectedPagesCount);
    }
    #endregion

    #region Respawn Method
    public void ReturnToBed()
    {
        PlayerRespawnManager.SetPlayerInBed();
    }
    #endregion
}