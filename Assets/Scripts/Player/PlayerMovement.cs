using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveDelta;
    private PlayerInput _playerInput;

    public Vector2 MoveDelta => _moveDelta;
    public bool IsPlayerMoving => _moveDelta.magnitude > 0f;

    private void OnEnable()
    {
        _playerInput.PlayerWalk.Enable();
    }

    private void OnDisable()
    {
        _playerInput.PlayerWalk.Disable();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CalculateMovement();
    }

    public void CalculateMovement()
    {
        _moveDelta = _playerInput.PlayerWalk.Move.ReadValue<Vector2>();
		_rigidbody.velocity = (_moveDelta * _speed);
    }
}
