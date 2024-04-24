using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObjectController : MonoBehaviour
{
    public Camera Camera;
    public GameObject LookObject;
    public EyeViewEffect EyeViewEffect;

    private float _cooldownTime = 1.0f;
    private float _nextUseTime = 0.0f;

    #region Update Methods
    private void Update()
    {
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        RaycastHit Object;

        if (Physics.Raycast(ray, out Object))
        {
            LookObject = Object.collider.gameObject;
        }
        else
        {
            LookObject = null;
        }

        if (Input.GetButton("Use") && LookObject.GetComponent<IinteractibleObject>() != null && Time.time > _nextUseTime)
        {
            var interactibleObject = LookObject.GetComponent<IinteractibleObject>();
            if (interactibleObject.InUse == false)
            {
                LookObject.GetComponent<IinteractibleObject>().UseObject();
            }
            else
            {
                LookObject.GetComponent<IinteractibleObject>().ReleaseObject();
            }

            _nextUseTime = Time.time + _cooldownTime;
        }
    }
    #endregion
}