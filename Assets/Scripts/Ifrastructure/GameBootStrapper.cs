using UnityEngine;

public class GameBootStrapper : MonoBehaviour
{
    private Game _game;

    private void Awake()
    {
        _game = new Game();

        DontDestroyOnLoad(this);
    }
}
