using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalking;
    private readonly int _directionX = Animator.StringToHash("X");
    private readonly int _directionY = Animator.StringToHash("Y");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        UpdateLayer();
        WalkingAnimation();
    }

    private void WalkingAnimation()
    {
        if (_playerMovement.IsPlayerMoving)
        {
            _animator.SetFloat(_directionX, _playerMovement.MoveDelta.x);
            _animator.SetFloat(_directionY, _playerMovement.MoveDelta.y);
        }
    }

    private void ActivateLayer(string layerName)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }

        int layerToActivate = _animator.GetLayerIndex(layerName);
        _animator.SetLayerWeight(layerToActivate, 1);
    }

    private void UpdateLayer()
    {
        if (_playerMovement.IsPlayerMoving)
        {
            ActivateLayer(layerWalking);
        }
        else 
        {
            ActivateLayer(layerIdle);
        }
    }
}
