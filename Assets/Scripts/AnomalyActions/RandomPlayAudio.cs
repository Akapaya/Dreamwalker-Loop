using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudio : MonoBehaviour, IAnomaly
{
    [SerializeField] private float _minTime = 5;
    [SerializeField] private float _maxTime = 10;

    [SerializeField] private AudioSource _audio;

    #region Process Anomaly
    public void OnActivateAnomaly()
    {
        StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));

        _audio.Play();

        StartCoroutine(PlaySound());
    }

    public void OnDeactivateAnomaly()
    {
        StopAllCoroutines();
    }
    #endregion
}
