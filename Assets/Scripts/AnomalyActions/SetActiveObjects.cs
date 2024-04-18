using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObjects : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<GameObject> _objectsToActivesList;

    public void OnActivateAnomaly()
    {
        foreach (GameObject obj in _objectsToActivesList)
        {
            obj.SetActive(true);
        }
    }

    public void OnDeactivateAnomaly()
    {
        foreach (GameObject obj in _objectsToActivesList)
        {
            obj.SetActive(false);
        }
    }
}
