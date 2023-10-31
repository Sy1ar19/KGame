using Assets.Scripts.Data;
using Assets.Scripts.Ifrastructure.Services;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMover : MonoBehaviour, ISavedProgress
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

    public void LoadProgress(PlayerProgress playerProgress)
    {
        if (CurrentLevel() == playerProgress.WorldData.PositionOnLevel.level)
        {
            Vector3Data savedPosition = playerProgress.WorldData.PositionOnLevel.Position;

            if (savedPosition != null)
            {
                Warp(savedPosition: savedPosition);
            }
        }
    }

    private void Warp(Vector3Data savedPosition)
    {
        _characterController.enabled = false;
        transform.position = savedPosition.AsUnityVector().AddY(_characterController.height);
        _characterController.enabled = true;
    }

    private static string CurrentLevel()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void UpdateProgress(PlayerProgress playerProgress) =>
        playerProgress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
}
