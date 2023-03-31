using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalking;
    private readonly int _directionX = Animator.StringToHash("X");
    private readonly int _directionY = Animator.StringToHash("Y");
    private readonly int _isPlayerDefeated = Animator.StringToHash("IsPlayerDefeated");

    private void OnEnable()
    {
        PlayerHealth.PlayerDefeatedEvent += DefeatedAnimation;
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDefeatedEvent -= DefeatedAnimation;
    }

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

    private void DefeatedAnimation()
    {
        if (IsLayerActive(layerIdle))
        {
            _animator.SetBool(_isPlayerDefeated, true);
        }
    }

    public void RestorePlayerAnimation()
    {
        ActivateLayer(layerIdle);
        _animator.SetBool(_isPlayerDefeated, false);
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

    private bool IsLayerActive(string layerName)
    {
        int layerToCheck = _animator.GetLayerIndex(layerName);
        if (_animator.GetLayerWeight(layerToCheck) == 0)
        {
            return false; 
        }
        return true;
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
