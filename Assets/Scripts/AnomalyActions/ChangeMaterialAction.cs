using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialAction : MonoBehaviour, IAnomaly
{
    [SerializeField] private List<MeshRenderer> _materialsToChangeList;
    [SerializeField] private List<Material> _defaultMaterialsList;

    [SerializeField] private Material _material;

    #region Process Anomaly
    public void OnActivateAnomaly()
    {
        foreach (MeshRenderer obj in _materialsToChangeList)
        {
            _defaultMaterialsList.Add(obj.GetComponent<MeshRenderer>().material);
            obj.GetComponent<MeshRenderer>().material = _material;
        }
    }

    public void OnDeactivateAnomaly()
    {
        int index = 0;

        foreach (MeshRenderer obj in _materialsToChangeList)
        {
            obj.GetComponent<MeshRenderer>().material = _defaultMaterialsList[index];
            index++;
        }
    }
    #endregion
}