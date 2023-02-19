using Cysharp.Threading.Tasks;

namespace App.Services.Spawner
{
    public interface ISpawner<T>
    {
        UniTask<T> SpawnAsync();
    }
}