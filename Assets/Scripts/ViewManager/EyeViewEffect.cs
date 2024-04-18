using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EyeViewEffect : MonoBehaviour
{
    ColorAdjustments ColorAdjustments;

    [Header("Base Values")]
    [SerializeField] private float modificationExposureValueByTime = 25;
    [SerializeField] private float targetExposure = -10;
    [SerializeField] private float timeExposureModification = 0.04f;
    [SerializeField] private float toleranceDistance = 2;

    float exposureValue = 25;
    float targetExposureValue = -10;

    public UnityEvent OnConcludedCloseEffect = new UnityEvent();

    #region StartMethods
    private void Start()
    {
        if (GameObject.Find("GlobalVolume").GetComponent<Volume>().profile.TryGet<ColorAdjustments>(out var tmp))
        {
            ColorAdjustments = tmp;
        }
    }
    #endregion

    #region Effects
    [ContextMenu("CloseEyesHold")]
    public void CloseEyesHold()
    {
        if ( ColorAdjustments.postExposure.value != targetExposure)
        {
            exposureValue = modificationExposureValueByTime;
            targetExposureValue = targetExposure;
            StartCoroutine(EyeEffectRoutine());
        }
        else
        {
            OnConcludedCloseEffect.Invoke();
        }
    }

    [ContextMenu("EyeViewOpen")]
    public void OpenEyes()
    {
        if (ColorAdjustments.postExposure.value != 0)
        {
            exposureValue = modificationExposureValueByTime * -1;
            targetExposureValue = 0;
            StartCoroutine(EyeEffectRoutine());
        }
    }
    #endregion

    #region Coroutine
    private IEnumerator EyeEffectRoutine()
    {
        ColorAdjustments.postExposure.value -= exposureValue;

        yield return new WaitForSeconds(timeExposureModification);

        if (IsApproximately(ColorAdjustments.postExposure.value, targetExposureValue))
        {
            ColorAdjustments.postExposure.value = targetExposureValue;
        }
    }
    #endregion


    public bool IsApproximately(float a, float b)
    {
        return Mathf.Abs(a - b) <= toleranceDistance;
    }
}