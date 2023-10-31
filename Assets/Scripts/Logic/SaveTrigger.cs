using Assets.Scripts.Ifrastructure.Services;
using Assets.Scripts.Ifrastructure.States;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    private ISavedLoadService _saveloadService;

    [SerializeField] private BoxCollider _collider;

    private void Awake()
    {
        _saveloadService = AllServices.Container.Single<ISavedLoadService>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeroMover hero))
        {
            _saveloadService.SaveProgress();
            Debug.Log("SAVE");
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (_collider == null)
            return;

        Gizmos.color = new Color32(30, 200, 30, 130);
        Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
    }
}
