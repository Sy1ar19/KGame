using Assets.Scripts.Ifrastructure.Services;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject heroInitialPoint);
        void CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}