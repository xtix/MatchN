using App.Core.Object;
using App.Core.Pool.Reinitialize;
using App.Core.Pool.Reset;

namespace App.View.Mono.Linkables.Item
{
    public interface IItemView: IView,
        IDespawnObservable<IItemView>,
        IPoolResettable,
        IPoolReinitializable,
        IDestructible
    {
    }
}