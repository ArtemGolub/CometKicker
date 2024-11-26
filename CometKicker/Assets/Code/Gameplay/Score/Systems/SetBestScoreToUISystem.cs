using Entitas;
using UnityEngine;

namespace Code.Meta.UI
{
    public class SetBestScoreToUISystem : IExecuteSystem
    {
        private readonly IBestScoreBarService _bestScoreBarService;
        private readonly IGroup<MetaEntity> _scoreStorages;

        public SetBestScoreToUISystem(MetaContext meta, IBestScoreBarService bestScoreBarService)
        {
            _bestScoreBarService = bestScoreBarService;
            _scoreStorages = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.ScoreStorage,
                MetaMatcher.MaxScore
                ));
        }

        public void Execute()
        {
            foreach (MetaEntity storage in _scoreStorages)
            {
                var bestScoreBar = _bestScoreBarService.GetBestScoreBar();
                if (bestScoreBar == null) continue;
                bestScoreBar.SetScore(storage.MaxScore);
            }
        }
    }

}