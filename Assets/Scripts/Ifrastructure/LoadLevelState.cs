using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private const string SampleScene = "Test";
    private const string HeroPath = "Hero/TT_Archer";
    private const string HudPath = "HUD/HUD";
    private const string InitialPointTag = "PlayerInitialPoint";

    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _loadingCurtain = loadingCurtain;
    }

    public void Enter(string sceneName)
    {
        _loadingCurtain.Show();
        _sceneLoader.Load(sceneName, onLoaded);
    }

    public void Exit()
    {
        _loadingCurtain.Hide();
    }

    private void onLoaded()
    {
        var heroInitialPoint = GameObject.FindWithTag(InitialPointTag);
        GameObject hero = Instantiate(HeroPath, heroSpawnPoint: heroInitialPoint.transform.position);
        Instantiate(HudPath);

        CameraFollow(hero);

        _gameStateMachine.Enter<GameLoopState>();
    }

    private static void CameraFollow(GameObject hero)
    {
        Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }

    private static GameObject Instantiate(string path)
    {
        var heroPrefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(heroPrefab);
    }

    private static GameObject Instantiate(string path, Vector3 heroSpawnPoint)
    {
        var heroPrefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(heroPrefab, heroSpawnPoint, Quaternion.identity);
    }
}