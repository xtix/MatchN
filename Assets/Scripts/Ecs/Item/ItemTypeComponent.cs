namespace App.Ecs.Item
{
    public readonly struct ItemTypeComponent
    {
        public readonly int Value;

        public ItemTypeComponent(int value)
        {
            Value = value;
        }
    }
}