using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeAction : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<GameObject> _objectsToResizeList;
    [SerializeField] private List<Vector3> _defaultObjectsSize;

    [SerializeField] private float speedSize;
    [SerializeField] private Vector3 sizeVector;

    private bool OnResize = false;

    public void OnActivateAnomaly()
    {
        OnResize = true;

        foreach (GameObject obj in _objectsToResizeList)
        {
            _defaultObjectsSize.Add(obj.transform.localScale);
        }
    }

    private void Update()
    {
        if (OnResize)
        {
            foreach (GameObject obj in _objectsToResizeList)
            {
                obj.transform.localScale = obj.transform.localScale + (sizeVector * speedSize);
            }
        }
    }

    public void OnDeactivateAnomaly()
    {
        OnResize = false;

        int index = 0;

        foreach (GameObject obj in _objectsToResizeList)
        {
            obj.transform.localScale = _defaultObjectsSize[index];
            index++;
        }
    }
}