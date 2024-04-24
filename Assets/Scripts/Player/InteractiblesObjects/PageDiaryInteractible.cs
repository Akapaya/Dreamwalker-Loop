using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PageDiaryInteractible : MonoBehaviour, IinteractibleObject
{
    private bool holdingPage = false;

    public UnityEvent OnReleasePage = new UnityEvent();
    public UnityEvent OnUsePage = new UnityEvent();

    public bool InUse { get => holdingPage; set => holdingPage = value; }

    #region Interactible Methods
    public void ReleaseObject()
    {
        holdingPage = false;
        OnReleasePage.Invoke();
    }

    public void UseObject()
    {
        holdingPage = true;
        OnUsePage.Invoke();
    }
    #endregion
}