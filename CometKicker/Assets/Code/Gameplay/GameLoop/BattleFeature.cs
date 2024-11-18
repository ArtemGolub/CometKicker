using Code.Audios.Audio;
using Code.Common.Destruct;
using Code.Common.Helpers;
using Code.Gameplay.Audio;
using Code.Gameplay.Backgrounds;
using Code.Gameplay.Cameras;
using Code.Gameplay.Cheats;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.LifeTime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.GameOver.Systems;
using Code.Gameplay.Input;
using Code.Gameplay.Score;
using Code.Gameplay.TextureMovement;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            ProfilerInit(systems);
        }
        
        private void NormalInit(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());

            Add(systems.Create<HeroFeature>());
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<BackgroundFeature>());
            Add(systems.Create<TextureMovementFeature>());

            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<DeathFeature>());


            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<EffectApplicationFeature>());
            Add(systems.Create<ArmamentFeature>());
            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<EffectFeature>());
            

            Add(systems.Create<GameOverOnHeroDeathSystem>());
            
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<ScoreFeature>());
            Add(systems.Create<StatsFeature>());
            Add(systems.Create<AudioFeature>());


            Add(systems.Create<ProcessDestructedFeature>());
        }

        private void ProfilerInit(ISystemFactory systems)
        {
            ProfilerHelper.ProfileAction("Input Feature", () => Add(systems.Create<InputFeature>()));
            ProfilerHelper.ProfileAction("Bind View", () => Add(systems.Create<BindViewFeature>()));
            

            ProfilerHelper.ProfileAction("HeroFeature", () => Add(systems.Create<HeroFeature>()));
            ProfilerHelper.ProfileAction("CameraFeature", () => Add(systems.Create<CameraFeature>()));
            
            ProfilerHelper.ProfileAction("BackgroundFeature", () => Add(systems.Create<BackgroundFeature>()));
            ProfilerHelper.ProfileAction("TextureMovementFeature", () => Add(systems.Create<TextureMovementFeature>()));
            ProfilerHelper.ProfileAction("EnemyFeature", () => Add(systems.Create<EnemyFeature>()));
            ProfilerHelper.ProfileAction("DeathFeature", () => Add(systems.Create<DeathFeature>()));
            ProfilerHelper.ProfileAction("CollectTargetsFeature", () => Add(systems.Create<CollectTargetsFeature>()));
            ProfilerHelper.ProfileAction("EffectApplicationFeature",
                () => Add(systems.Create<EffectApplicationFeature>()));
            ProfilerHelper.ProfileAction("ArmamentFeature", () => Add(systems.Create<ArmamentFeature>()));
            ProfilerHelper.ProfileAction("AbilityFeature", () => Add(systems.Create<AbilityFeature>()));
            ProfilerHelper.ProfileAction("EffectFeature", () => Add(systems.Create<EffectFeature>()));
         //   ProfilerHelper.ProfileAction("StatusFeature", () => Add(systems.Create<StatusFeature>()));
          //  ProfilerHelper.ProfileAction("EnchantFeature", () => Add(systems.Create<EnchantFeature>()));
            ProfilerHelper.ProfileAction("GameOverOnHeroDeathSystem",
                () => Add(systems.Create<GameOverOnHeroDeathSystem>()));
            ProfilerHelper.ProfileAction("MovementFeature", () => Add(systems.Create<MovementFeature>()));
            ProfilerHelper.ProfileAction("ScoreFeature", () => Add(systems.Create<ScoreFeature>()));
            ProfilerHelper.ProfileAction("StatsFeature", () => Add(systems.Create<StatsFeature>()));
            ProfilerHelper.ProfileAction("AudioFeature", () => Add(systems.Create<AudioFeature>()));
            ProfilerHelper.ProfileAction("ProcessDestructedFeature",
                () => Add(systems.Create<ProcessDestructedFeature>()));            
            // ProfilerHelper.ProfileAction("CheatsFeature",
            //     () => Add(systems.Create<CheatsFeature>()));
        }
    }
}