using Code.Gameplay.UI;
using Code.Gameplay.UI.Services;
using Entitas;

namespace Code.Gameplay.Score.Systems
{
    public class SetCurrentScoreToUISystem: IExecuteSystem
    {
        private readonly ICurrentScoreBarService _currentScoreBarService;
        private readonly IGroup<MetaEntity> _scoreStorages;
        
        public SetCurrentScoreToUISystem(MetaContext meta, ICurrentScoreBarService currentScoreBarService)
        {
            _currentScoreBarService = currentScoreBarService;
            _scoreStorages = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.ScoreStorage, 
                MetaMatcher.CurrentScore));
        }

        public void Execute()
        {
            foreach (MetaEntity storage in _scoreStorages)
            {
                CurrentScoreBarController controller = _currentScoreBarService.GetCurrentScoreBar();
                if(!controller) continue;
                controller.SetScore(storage.CurrentScore);
            }
        }
    }
}