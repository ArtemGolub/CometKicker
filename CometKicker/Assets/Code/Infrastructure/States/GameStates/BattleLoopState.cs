using Code.Common.Helpers;
using Code.Gameplay;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private readonly IBattleFeatureService _battleFeatureService;

        private readonly GameContext _gameContext;
        private BattleFeature _battleFeature;

        public BattleLoopState(GameContext gameContext, ISystemFactory systemFactory, IBattleFeatureService battleFeatureService)
        {

            _gameContext = gameContext;
            _systems = systemFactory;
            _battleFeatureService = battleFeatureService;
        }

        public override void Enter()
        {
            _battleFeatureService.Activate();
        }        
        // public override void Enter()
        // {
        //     Activate();
        // }
        // public void Activate()
        // {
        //     _battleFeature = _systems.Create<BattleFeature>(); 
        //     _battleFeature.Initialize();
        // }
        protected override void OnUpdate()
        {
            ProfilerHelper.ProfileAction("UpdateBattleFeature", () => UpdateBattleFeature());
        }

        private void UpdateBattleFeature()
        {
            _battleFeatureService.Execute();
        }        
        
        // private void UpdateBattleFeature()
        // {
        //     _battleFeature.Execute();
        //     _battleFeature.Cleanup();
        // }

        protected override void ExitOnEndOfFrame()
        {
         //  _battleFeatureService.Deactivate();
        }        
        
        // protected override void ExitOnEndOfFrame()
        // {
        //     _battleFeature.DeactivateReactiveSystems();
        //     _battleFeature.ClearReactiveSystems();
        //
        //     DestructEntities();
        //
        //     _battleFeature.Cleanup();
        //     _battleFeature.TearDown();
        //     _battleFeature = null;
        // }
        // private void DestructEntities()
        // {
        //     foreach (GameEntity entity in _gameContext.GetEntities())
        //     {
        //         if (entity.isPersistent)
        //         {
        //             Debug.Log($"Ignore {entity.Id}");
        //             continue;
        //         }
        //         entity.isDestructed = true;
        //     }
        // }

    }
}