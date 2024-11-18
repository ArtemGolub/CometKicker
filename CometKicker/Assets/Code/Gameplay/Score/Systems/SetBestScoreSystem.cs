using Entitas;

namespace Code.Gameplay.Score.Systems
{
    public class SetBestScoreSystem: IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _scoreStorages;

        public SetBestScoreSystem(MetaContext meta)
        {
            _scoreStorages = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.ScoreStorage,
                MetaMatcher.CurrentScore,
                MetaMatcher.MaxScore
            ));
        }

        public void Execute()
        {
            foreach (MetaEntity storage in _scoreStorages)
            {
                if (storage.CurrentScore >= storage.MaxScore)
                {
                    storage.ReplaceMaxScore(storage.CurrentScore);
                }
            }
        }
    }
}