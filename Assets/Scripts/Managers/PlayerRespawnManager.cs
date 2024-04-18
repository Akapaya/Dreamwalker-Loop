using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerGO;
    [SerializeField] private Transform _bedRespawnPosition;

    public void SetPlayerInBed()
    {
        _playerGO.transform.position = _bedRespawnPosition.position;
    }
}