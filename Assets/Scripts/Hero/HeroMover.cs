using UnityEngine;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    private CharacterController _characterController;
    private Camera _camera;
    private IInputService _inputService;
    private Transform _transform;

    private void Awake()
    {
        _inputService = Game.InputService;
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (_inputService.Axis.sqrMagnitude > 0.00000001)
        {
            movementVector = _camera.transform.TransformDirection(_inputService.Axis);

            movementVector.y = 0f;
            movementVector.Normalize();

            _transform.forward = movementVector;
        }

        movementVector += Physics.gravity;

        _characterController.Move(movementVector * _movementSpeed * Time.deltaTime);
    }
}
