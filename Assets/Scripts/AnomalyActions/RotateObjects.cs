using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<GameObject> _objectsToRotateList;
    [SerializeField] private List<Quaternion> _defaultObjectsRotation;

    [SerializeField] private float _peedRotation;
    [SerializeField] private Vector3 _rotationVector;

    private bool onRotation = false;

    #region Process Anomaly
    public void OnActivateAnomaly()
    {
        onRotation = true;

        foreach (GameObject obj in _objectsToRotateList)
        {
            _defaultObjectsRotation.Add(obj.transform.rotation);
        }
    }

    private void Update()
    {
        if(onRotation)
        {
            foreach (GameObject obj in _objectsToRotateList)
            {
                obj.transform.Rotate(_rotationVector * _peedRotation);
            }
        }
    }

    public void OnDeactivateAnomaly()
    {
        onRotation = false;

        int index = 0;

        foreach (GameObject obj in _objectsToRotateList)
        {
            obj.transform.rotation = _defaultObjectsRotation[index];
            index++;
        }
    }
    #endregion
}
