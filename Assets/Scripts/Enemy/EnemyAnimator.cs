using System;
using UnityEngine;
using AnimatorState = Assets.Scripts.Logic.AnimatorState;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        private readonly int _deathStateHash = Animator.StringToHash("die");
        private readonly int _moveStateHash = Animator.StringToHash("move");
        private readonly int _attackStateHash = Animator.StringToHash("attack");

        private Animator _animator;

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath() =>
            _animator.SetTrigger(Die);

        public void PlayMove(bool state) =>
            _animator.SetBool(IsMoving, state);

        public void PlayAttack(bool state) =>
            _animator.SetBool(IsAttacking, state);

        private void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        private void ExitedState(int stateHash) =>
            StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;

            if (stateHash == _attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == _moveStateHash)
                state = AnimatorState.Move;
            else if (stateHash == _deathStateHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}