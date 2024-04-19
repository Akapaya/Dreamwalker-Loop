using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<GameObject> _objectsToRotateList;
    [SerializeField] private List<Quaternion> _defaultObjectsRotation;

    [SerializeField] private float speedRotation;
    [SerializeField] private Vector3 rotationVector;

    private bool OnRotation = false;

    public void OnActivateAnomaly()
    {
        OnRotation = true;

        foreach (GameObject obj in _objectsToRotateList)
        {
            _defaultObjectsRotation.Add(obj.transform.rotation);
        }
    }

    private void Update()
    {
        if(OnRotation)
        {
            foreach (GameObject obj in _objectsToRotateList)
            {
                obj.transform.Rotate(rotationVector * speedRotation);
            }
        }
    }

    public void OnDeactivateAnomaly()
    {
        OnRotation = false;

        int index = 0;

        foreach (GameObject obj in _objectsToRotateList)
        {
            obj.transform.rotation = _defaultObjectsRotation[index];
            index++;
        }
    }
}
