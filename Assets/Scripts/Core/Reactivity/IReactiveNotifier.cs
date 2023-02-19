namespace App.Core.Reactivity
{
    public interface IReactiveNotifier<in T>
    {
        void Notify(T value);
    }
}