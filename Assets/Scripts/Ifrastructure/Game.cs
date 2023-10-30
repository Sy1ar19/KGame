using Assets.Scripts.Ifrastructure.Services;
using Assets.Scripts.Ifrastructure.States;

namespace Assets.Scripts.Ifrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}