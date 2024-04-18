using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDeactiveObjects : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<GameObject> _objectsToDeactivesList;

    public void OnActivateAnomaly()
    {
        foreach (GameObject obj in _objectsToDeactivesList)
        {
            obj.SetActive(false);
        }
    }

    public void OnDeactivateAnomaly()
    {
        foreach (GameObject obj in _objectsToDeactivesList)
        {
            obj.SetActive(true);
        }
    }
}
