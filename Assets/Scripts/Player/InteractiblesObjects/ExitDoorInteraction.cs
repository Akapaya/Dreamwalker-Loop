using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitDoorInteraction : MonoBehaviour, IinteractibleObject
{
    private bool isHoldingDoor = false;

    public UnityEvent OnUseDoor = new UnityEvent();
    public UnityEvent<bool> OnUsingDoor = new UnityEvent<bool>();

    public bool InUse { get => isHoldingDoor; set => isHoldingDoor = value; }

    #region Update Methods
    private void Update()
    {
        if (isHoldingDoor)
        {
            OnUsingDoor.Invoke(false);
        }
    }
    #endregion

    #region Interactible Methods
    public void UseObject()
    {
        if(isHoldingDoor == false)
        {
            OnUseDoor.Invoke();
        }
        isHoldingDoor = true;
    }

    public void ReleaseObject()
    {
        isHoldingDoor = false;
    }
    #endregion
}