using Assets.Scripts.Ifrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject heroInitialPoint);
        void CreateHud();
    }
}