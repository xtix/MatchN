using Leopotam.Ecs;

namespace App.Services.SystemComposer
{
    public interface ISystemComposer
    {
        public EcsSystems Systems { get; }
    }
}