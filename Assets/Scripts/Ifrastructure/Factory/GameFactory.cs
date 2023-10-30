using Assets.Scripts.Ifrastructure.AssetManagement;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.Factory
{
    public partial class GameFactory :  IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject heroInitialPoint)
        {
            return _assets.Instantiate(AssetPath.HeroPath, heroSpawnPoint: heroInitialPoint.transform.position);
        }

        public void CreateHud()
        {
            _assets.Instantiate(AssetPath.HudPath);
        }
    }
}