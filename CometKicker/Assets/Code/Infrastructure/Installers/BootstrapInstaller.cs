using Code.Common.EntityIndices;
using Code.Gameplay;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Audio.Services;
using Code.Gameplay.Backgrounds.Factory;
using Code.Gameplay.Cameras;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Cheats.Services;
using Code.Gameplay.Common.AABB;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Features.Statuses.Factory;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.Pause.Services;
using Code.Gameplay.StaticData;
using Code.Gameplay.UI.Services;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views.Fabrics;
using Code.Meta.UI.HUD.SettingsWindow.Services;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using RSG;
using UnityEngine;

using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindAssetManagementServices();
            BindCommonServices();
            BindSystemFactory();
            BindUIFactories();
            BindContexts();
            BindGameplayServices();
            BindUIServices();
            BindAuidioServices();
            BindCameraProvider();
            BindGameplayFactories();
            BindStateMachine();
            BindStateFactory();
            BindInfrastructureServices();
            BindGameStates();
            BindProgressServices();
            BindEntityIndices();

           // BindCheats();
        }



        private void BindCheats()
        {
            Container.Bind<IUICheatService>().To<UICheatService>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
        private void BindEntityIndices()
        {
            Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
        }
        private void BindStateFactory()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActualizeProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GamePauseState>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();

            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
            Container.Bind<AudioContext>().FromInstance(Contexts.sharedInstance.audio).AsSingle();
        }

        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }

        private void BindProgressServices()
        {
            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IStatusApplier>().To<StatusApplier>().AsSingle();
            Container.Bind<IAbilityUpgradeService>().To<AbilityUpgradeService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<IBattleFeatureService>().To<BattleFeatureService>().AsSingle();
        }

        private void BindGameplayFactories()
        {
            Container.Bind<IGameEntityViewFactory>().To<GameGameEntityViewFactory>().AsSingle();
            Container.Bind<IAudioEntityViewFactory>().To<AudioEntityViewFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IBackgroundFactory>().To<BackgroundFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
            Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
            Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
            Container.Bind<IAbilityFXFactory>().To<AbilityFXFactory>().AsSingle();
            Container.Bind<IAudioFactory>().To<AudioFactory>().AsSingle();
        }


        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IAABBPhysicsService>().To<AABBPhysicsService>().AsSingle();
        }

        private void BindInputService()
        {
            if (Application.isMobilePlatform)
            {
                Container.Bind<ITouchInputService>().To<TouchInputService>().AsSingle();
            }
            else
            {
                Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            }
        }

        private void BindUIServices()
        {
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IBestScoreBarService>().To<BestScoreBarService>().AsSingle();
            Container.Bind<ICurrentScoreBarService>().To<CurrentScoreBarService>().AsSingle();
            Container.Bind<IHPBarService>().To<HPBarService>().AsSingle();
            Container.Bind<IGamePauseButtonService>().To<GamePauseButtonService>().AsSingle();
            Container.Bind<IPauseWindowService>().To<PauseWindowService>().AsSingle();
        }
        private void BindAuidioServices()
        {
            Container.Bind<ISettingsService>().To<SettingsService>().AsSingle();
        }

        private void BindUIFactories()
        {
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
        }

        public void Initialize()
        {
            Promise.UnhandledException += LogPromiseException;
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void LogPromiseException(object sender, ExceptionEventArgs e)
        {
            Debug.LogError(e.Exception);
        }
    }
}