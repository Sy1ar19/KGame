using Assets.Scripts.Ifrastructure.Services;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject HeroGameObject { get; }

        event Action HeroCreated;
        GameObject CreateHero(GameObject heroInitialPoint);

        void CreateHud();
        void Cleanup();
    }
}