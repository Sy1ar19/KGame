﻿using Assets.Scripts.Data;

namespace Assets.Scripts.Ifrastructure.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress playerProgress);
    }

    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress playerProgress);
    }
}