using UnityEngine;

public class Game : MonoBehaviour
{
    public static IInputService InputService;
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
    }
}
