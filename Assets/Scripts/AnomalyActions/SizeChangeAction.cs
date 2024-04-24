using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeAction : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<GameObject> _objectsToResizeList;
    [SerializeField] private List<Vector3> _defaultObjectsSize;

    [SerializeField] private float _speedSize;
    [SerializeField] private Vector3 _sizeVector;

    private bool onResize = false;

    #region Process Anomaly
    public void OnActivateAnomaly()
    {
        onResize = true;

        foreach (GameObject obj in _objectsToResizeList)
        {
            _defaultObjectsSize.Add(obj.transform.localScale);
        }
    }

    private void Update()
    {
        if (onResize)
        {
            foreach (GameObject obj in _objectsToResizeList)
            {
                obj.transform.localScale = obj.transform.localScale + (_sizeVector * _speedSize);
            }
        }
    }

    public void OnDeactivateAnomaly()
    {
        onResize = false;

        int index = 0;

        foreach (GameObject obj in _objectsToResizeList)
        {
            obj.transform.localScale = _defaultObjectsSize[index];
            index++;
        }
    }
    #endregion
}