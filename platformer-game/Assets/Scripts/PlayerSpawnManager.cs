using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject[] _spawnPoints;

    void Awake()
    {
        Instantiate(_player, _spawnPoints[Random.Range(0, 2)].transform.position, Quaternion.identity);
    }
}
