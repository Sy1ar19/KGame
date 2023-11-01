using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimumSpeed = 0.001f;

        private EnemyAnimator _animator;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _animator = GetComponent<EnemyAnimator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_agent.velocity.magnitude > MinimumSpeed && _agent.remainingDistance > _agent.radius)
                _animator.PlayMove(true);
            else
                _animator.PlayMove(false);
        }
    }
}