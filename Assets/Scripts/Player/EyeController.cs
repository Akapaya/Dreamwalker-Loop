using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EyeController : MonoBehaviour
{
    private bool isHoldingEye = false;

    public UnityEvent OnHoldingToCloseEye = new UnityEvent();
    public UnityEvent OnReleaseCloseEye = new UnityEvent();

    void Update()
    {
        if (Input.GetButtonDown("CloseEye"))
        {
            isHoldingEye = true;
        }
        else if (Input.GetButtonUp("CloseEye"))
        {
            isHoldingEye = false;
        }
    }

    private void FixedUpdate()
    {
        if(isHoldingEye)
        {
            OnHoldingToCloseEye.Invoke();
        }
        else
        {
            OnReleaseCloseEye.Invoke();
        }
    }

    public void SetHoldingEyeToFalse()
    {
        isHoldingEye=false;
    }
}