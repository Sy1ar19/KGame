using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private float _distance;
    [SerializeField] private float _offsetY;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);

        Vector3 position = rotation * new Vector3(0, 0, _distance) + FollowingPointPosition();

        _transform.rotation = rotation;
        _transform.position = position;
    }

    public void Follow(GameObject following)=>
            _target = following.transform;

    private Vector3 FollowingPointPosition()
    {
        Vector3 followingPosition = _target.position;
        followingPosition.y += _offsetY;

        return followingPosition;
    }

}
