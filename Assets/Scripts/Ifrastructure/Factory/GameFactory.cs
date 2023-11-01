using Assets.Scripts.Ifrastructure.AssetManagement;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.Factory
{
    public partial class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public event Action HeroCreated;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameObject HeroGameObject { get; private set; }

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject heroInitialPoint)
        {
            HeroGameObject = InstantiaterRegistered(AssetPath.HeroPath, heroInitialPoint.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        public void CreateHud() =>
            InstantiaterRegistered(AssetPath.HudPath);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private GameObject InstantiaterRegistered(string prefabPath, Vector3 position)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }  

        private GameObject InstantiaterRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
    }
}