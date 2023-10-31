using Assets.Scripts.Ifrastructure.AssetManagement;
using Assets.Scripts.Ifrastructure.Factory;
using Assets.Scripts.Ifrastructure.Services;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;
using UnityEngine;
using static IInputService;

namespace Assets.Scripts.Ifrastructure.States
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _allServices = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {

        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<IInputService>(RegisterInputService());
            _allServices.RegisterSingle<IAssets>(new AssetProvider());
            _allServices.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(_allServices.Single<IAssets>()));
            _allServices.RegisterSingle<ISavedLoadService>(new SaveLoadService(_allServices.Single<IPersistentProgressService>(), _allServices.Single<IGameFactory>()));
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else
                return new MobileInputService();
        }
    }
}