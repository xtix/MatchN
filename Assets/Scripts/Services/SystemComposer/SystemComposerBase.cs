using System;
using System.Collections.Generic;
using Leopotam.Ecs;

namespace App.Services.SystemComposer
{
    public abstract class SystemComposerBase : ISystemComposer
    {
        public EcsSystems Systems => _systems.Value;

        private readonly EcsWorld _ecsWorld;
        private readonly List<IEcsSystem> _ecsSystems;
        private readonly Lazy<EcsSystems> _systems;

        public SystemComposerBase(EcsWorld ecsWorld, List<IEcsSystem> ecsSystems)
        {
            _ecsWorld = ecsWorld;
            _ecsSystems = ecsSystems;

            _systems = new Lazy<EcsSystems>(Compose);
        }

        protected virtual EcsSystems Compose()
        {
            EcsSystems systems = new EcsSystems(_ecsWorld);

            foreach (IEcsSystem system in _ecsSystems) 
                systems.Add(system);

            return AddOneFrameComponents(systems);
        }

        protected virtual EcsSystems AddOneFrameComponents(EcsSystems systems)
        {
            return systems;
        }
    }
}