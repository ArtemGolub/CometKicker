using System.Collections;
using System.Collections.Generic;
using Code.Gameplay.UI;
using Code.Meta.UI.HUD.SettingsWindow;
using UnityEngine;

public class BestScoreBarService : IBestScoreBarService
{
    private BestScoreBarController _bestBestScoreBarController;
    public BestScoreBarController SetBestScoreBar(BestScoreBarController bestBestScoreBarController)
    {
        _bestBestScoreBarController = bestBestScoreBarController;
        return _bestBestScoreBarController;
    }
    public BestScoreBarController GetBestScoreBar()
    {
        return _bestBestScoreBarController;
    }    
}
