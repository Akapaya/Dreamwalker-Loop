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
    [SerializeField] private float _modificationExposureValueByTime = 25;
    [SerializeField] private float _targetExposure = -10;
    [SerializeField] private float _timeExposureModification = 0.04f;
    [SerializeField] private float _toleranceDistance = 2;

    float _exposureValue = 25;
    float _targetExposureValue = -10;

    #region Unity Events
    public UnityEvent OnConcludedCloseEffect = new UnityEvent();
    public UnityEvent OnConcludedCloseEye = new UnityEvent();
    #endregion

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
    public void CloseEyesHold(bool isClosingEye)
    {
        if ( ColorAdjustments.postExposure.value != _targetExposure)
        {
            _exposureValue = _modificationExposureValueByTime;
            _targetExposureValue = _targetExposure;
            StartCoroutine(EyeEffectRoutine());
        }
        else
        {
            if (isClosingEye)
            {
                OnConcludedCloseEye.Invoke();
            }
            OnConcludedCloseEffect.Invoke();
        }
    }

    [ContextMenu("EyeViewOpen")]
    public void OpenEyes()
    {
        if (ColorAdjustments.postExposure.value != 0)
        {
            _exposureValue = _modificationExposureValueByTime * -1;
            _targetExposureValue = 0;
            StartCoroutine(EyeEffectRoutine());
        }
    }
    #endregion

    #region Coroutine
    private IEnumerator EyeEffectRoutine()
    {
        ColorAdjustments.postExposure.value -= _exposureValue;

        yield return new WaitForSeconds(_timeExposureModification);

        if (IsApproximately(ColorAdjustments.postExposure.value, _targetExposureValue))
        {
            ColorAdjustments.postExposure.value = _targetExposureValue;
        }
    }
    #endregion


    public bool IsApproximately(float a, float b)
    {
        return Mathf.Abs(a - b) <= _toleranceDistance;
    }
}