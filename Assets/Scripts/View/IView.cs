using Leopotam.Ecs;

namespace App.View
{
    public interface IView
    {
        void Link(in EcsEntity entity);
    }
}