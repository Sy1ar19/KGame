using Assets.Scripts.Ifrastructure.Services;
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
        _inputService = AllServices.Container.Single<IInputService>();
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (_inputService.Axis.sqrMagnitude > 0.0001f)
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
