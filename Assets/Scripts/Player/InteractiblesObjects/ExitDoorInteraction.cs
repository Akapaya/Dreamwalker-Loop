using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitDoorInteraction : MonoBehaviour, IinteractibleObject
{
    private bool isHoldingDoor = false;

    public UnityEvent OnUseDoor = new UnityEvent();

    public bool InUse { get => isHoldingDoor; set => isHoldingDoor = value; }

    private void Update()
    {
        if (isHoldingDoor)
        {
            OnUseDoor.Invoke();
        }
    }

    public void UseObject()
    {
        isHoldingDoor = true;
    }

    public void ReleaseObject()
    {
        isHoldingDoor = false;
    }
}