using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;
using YG;

namespace Code.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly MetaContext _metaContext;
        private readonly IProgressProvider _progressProvider;
        public bool HasSavedProgress => YandexGame.savesData.playerSave != String.Empty;

        public SaveLoadService(MetaContext metaContext, IProgressProvider progressProvider)
        {
            _metaContext = metaContext;
            _progressProvider = progressProvider;
        }

        public void CreateProgress()
        {
            Debug.Log("Creating new progress data");
            _progressProvider.SetProgressData(new ProgressData()
            {
            });
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();
            string saveJson = _progressProvider.ProgressData.ToJson();
            YandexGame.savesData.playerSave = saveJson;
            YandexGame.SaveProgress();
            Debug.Log($"RESULT MUST NOT BE NULL OR EMPTY => Progress saved: {saveJson}");
        }

        public void LoadProgress()
        {
            string progressDataYG = String.Empty;
            progressDataYG = YandexGame.savesData.playerSave;
            if (string.IsNullOrEmpty(progressDataYG))
            {
                Debug.LogError("No progress data found in YandexGame.savesData");
                return;
            }

            HydrateProgress(progressDataYG);
            Debug.Log("Progress loaded successfully");
        }


        private void HydrateProgress(string serializedProgress)
        {
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());
            HydrateMetaEntities();
        }

        private void HydrateMetaEntities()
        {
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.MetaEntitySnapshots;
            foreach (EntitySnapshot snapshot in snapshots)
            {
                _metaContext
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progressProvider.EntityData.MetaEntitySnapshots = _metaContext
                .GetEntities()
                .Where(RequiresSave)
                .Select(e => e.AsSavedEntity())
                .ToList();
        }

        private static bool RequiresSave(MetaEntity e)
        {
            return e.GetComponents().Any(c => c is ISavedComponent);
        }
    }
}