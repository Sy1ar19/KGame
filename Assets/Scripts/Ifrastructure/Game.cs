using UnityEngine;
using static IInputService;

public class Game : MonoBehaviour
{
    public static IInputService InputService;

    public Game()
    {
        RegisterInputService();
    }

    private static void RegisterInputService()
    {
        if (Application.isEditor)
            InputService = new StandaloneInputService();
        else
            InputService = new MobileInputService();
    }
}