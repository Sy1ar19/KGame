using Assets.Scripts.Data;
using Assets.Scripts.Ifrastructure.Factory;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Assets.Scripts.Ifrastructure.States
{
    public class SaveLoadService : ISavedLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService persistentProgressService,IGameFactory gameFactory)
        {
            _persistentProgressService = persistentProgressService;
            _gameFactory = gameFactory;
        }


        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(ProgressKey)?
            .ToDeserialized <PlayerProgress>();

        public void SaveProgress()
        {
            foreach(ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_persistentProgressService.Progress);

            PlayerPrefs.SetString(ProgressKey, _persistentProgressService.Progress.ToJson());
        }
    }
}