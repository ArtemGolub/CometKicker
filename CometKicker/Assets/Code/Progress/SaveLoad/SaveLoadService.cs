using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Progress.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "PlayerProgress";
    private const string FolderName = "DefaultSaves";
    private const string FileSaveName = "Save.json";

    
    private readonly MetaContext _metaContext;
    private readonly IProgressProvider _progressProvider;
    private readonly ITimeService _timeService;

    public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);
    public bool HasFileSavedProgress => File.Exists(GetSaveFilePath());
    private string GetSaveFilePath()
    {
      return Path.Combine(Application.persistentDataPath, FolderName, FileSaveName);
    }
    
    public SaveLoadService(MetaContext metaContext, IProgressProvider progressProvider, ITimeService timeService)
    {
      _timeService = timeService;
      _metaContext = metaContext;
      _progressProvider = progressProvider;
    }

    public void CreateProgress()
    {
      _progressProvider.SetProgressData(new ProgressData()
      {
          
      });
    }

    public void SaveProgress()
    {
      PreserveMetaEntities();
      string saveJson = _progressProvider.ProgressData.ToJson();
      PlayerPrefs.SetString(ProgressKey, saveJson);
      PlayerPrefs.Save();
      
      SaveProgressToFile(saveJson);
    }

    private void SaveProgressToFile(string saveJson)
    {
      string folderPath = Path.Combine(Application.persistentDataPath, FolderName);
      if (!Directory.Exists(folderPath))
      {
        Directory.CreateDirectory(folderPath);
      }
      string saveFilePath = GetSaveFilePath();
      File.WriteAllText(saveFilePath, saveJson);
      Debug.Log($"Save path: {Application.persistentDataPath}");
    }
    public void LoadProgress()
    {
      HydrateProgress(PlayerPrefs.GetString(ProgressKey));
    }

    private void HydrateProgress(string serializedProgress)
    {
      _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());
      HydrateMetaEntities();
    }

    private void LoadProgressFromFile()
    {
      string saveFilePath = GetSaveFilePath();
      if (File.Exists(saveFilePath))
      {
        string serializedProgress = File.ReadAllText(saveFilePath);
        HydrateProgress(serializedProgress);
      }
      else
      {
        Debug.LogWarning("Save file not found.");
      }
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