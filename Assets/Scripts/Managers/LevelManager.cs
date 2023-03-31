using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _playerRestorePoint;

    void Start()
    {
        
    }

    void Update()
    {
        RestorePlayer();
    }

    private void RestorePlayer()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_player.PlayerHealth.IsPlayerDefeated)
            {
                _player.transform.localPosition = _playerRestorePoint.position;
                _player.RestorePlayer();
            }
        }
    }
}
