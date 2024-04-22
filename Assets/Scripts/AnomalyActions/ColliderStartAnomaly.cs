using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStartAnomaly : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActive;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _objectToActive.SetActive(true);
        }
    }
}