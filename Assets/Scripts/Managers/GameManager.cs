using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int _collectedPagesCount = 0;
    [SerializeField] private int _instanciatedPagesCount = 0;
    private int _maxPagesCount = 5;

    [SerializeField] private PlayerRespawnManager PlayerRespawnManager;

    #region UnityEvents
    public UnityEvent<int> SetMaxPagesCount = new UnityEvent<int>();
    public UnityEvent<int> GetPage = new UnityEvent<int>();
    public UnityEvent ActivatePage = new UnityEvent();
    public UnityEvent DeactivatePage = new UnityEvent();
    #endregion

    public delegate bool CheckIfGetAllPages();
    public static CheckIfGetAllPages CheckIfGetAllPagesHandle;

    #region Start Methods
    private void OnEnable()
    {
        CheckIfGetAllPagesHandle += CheckIfAllPagesCollected;
    }

    private void OnDisable()
    {
        CheckIfGetAllPagesHandle -= CheckIfAllPagesCollected;
    }

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

        GetPage.Invoke(_collectedPagesCount);
    }

    [ContextMenu("Reset Pages Count")]
    public void ResetPagesCount()
    {
        _collectedPagesCount = 0;

        GetPage.Invoke(_collectedPagesCount);
    }
    #endregion

    #region Respawn Method
    public void ReturnToBed()
    {
        PlayerRespawnManager.SetPlayerInBed();
    }
    #endregion

    #region Page Check Method
    private int counter = 0;

    public void CheckPageInstance()
    {
        if(_instanciatedPagesCount < _maxPagesCount)
        {
            if (counter >= 3)
            {
                _instanciatedPagesCount++;
                ActivatePage.Invoke();
                counter = 0;
            }
            else
            {
                DeactivatePage.Invoke();
                counter++;
            }
        }
        else
        {
            DeactivatePage.Invoke();
        }
    }
    #endregion

    private bool CheckIfAllPagesCollected()
    {
        if(_collectedPagesCount >= _maxPagesCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}