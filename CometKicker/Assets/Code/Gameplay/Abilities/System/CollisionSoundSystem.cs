using System.Collections.Generic;
using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Abilities.System
{
    public class CollisionSoundSystem: IExecuteSystem
    {
        private readonly IAudioFactory _audioFactory;

        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CollisionSoundSystem(GameContext gameContext, IAudioFactory audioFactory)
        {
            _audioFactory = audioFactory;

            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.CollisionEffect,
                    GameMatcher.Reached
                ));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                _audioFactory.CreateSound(SoundTypeId.MeteorCollide);
            }
        }
    }
}