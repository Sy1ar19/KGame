using Assets.Scripts.Ifrastructure.States;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure
{
    public class GameBootStrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private void Awake()
        {
            _game = new Game(this, _loadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}