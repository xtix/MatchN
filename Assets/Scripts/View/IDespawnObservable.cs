using System;

namespace App.View
{
    public interface IDespawnObservable<T>
    {
        event Action<T> Despawned;
    }
}