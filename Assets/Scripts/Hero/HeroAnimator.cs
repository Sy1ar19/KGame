using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private static readonly int MoveHash = Animator.StringToHash("Walking");

    private Animator _animator;
    private CharacterController _characterController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _animator.SetFloat(MoveHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        print(_characterController.velocity.magnitude);
    }
}
