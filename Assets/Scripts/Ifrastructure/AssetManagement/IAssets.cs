using Assets.Scripts.Ifrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 heroSpawnPoint);
    }
}