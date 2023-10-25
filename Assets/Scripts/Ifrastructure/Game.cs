using UnityEngine;

public class Game : MonoBehaviour
{
    public static IInputService InputService;
    public GameStateMachine StateMachine;

    public Game()
    {
        StateMachine = new GameStateMachine();
    }
}
