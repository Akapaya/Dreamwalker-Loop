using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObjectController : MonoBehaviour
{
    public Camera cam;
    public GameObject lookObject;
    public EyeViewEffect EyeViewEffect;

    private float cooldownTime = 1.0f;
    private float nextUseTime = 0.0f;

    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        RaycastHit Object;

        if (Physics.Raycast(ray, out Object))
        {
            lookObject = Object.collider.gameObject;
        }
        else
        {
            lookObject = null;
        }

        if (Input.GetButton("Use") && lookObject.GetComponent<IinteractibleObject>() != null && Time.time > nextUseTime)
        {
            var interactibleObject = lookObject.GetComponent<IinteractibleObject>();
            if (interactibleObject.InUse == false)
            {
                lookObject.GetComponent<IinteractibleObject>().UseObject();
            }
            else
            {
                lookObject.GetComponent<IinteractibleObject>().ReleaseObject();
            }

            nextUseTime = Time.time + cooldownTime;
        }
    }
}