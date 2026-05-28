using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    private Rigidbody2D _rigidbody2D;
    private InputSystem_Actions _playerInput;
    private Vector2 _movementInput;

    void Awake()
    {
        _playerInput = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _playerInput.Player.Enable();
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _movementInput = _playerInput.Player.Move.ReadValue<Vector2>();
        _rigidbody2D.linearVelocity = _movementInput * _moveSpeed;
    }

    void OnDisable()
    {
        _playerInput.Player.Disable();
    }
}
