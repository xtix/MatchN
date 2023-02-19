using App.Core.Random;

namespace App.Services.Item.Type
{
    public class RandomItemTypePicker: IItemTypePicker
    {
        private readonly IRandom _random;
        private readonly int _itemTypesCount;
        
        public RandomItemTypePicker(IRandom random, int itemTypesCount)
        {
            _random = random;
            _itemTypesCount = itemTypesCount;
        }

        public int GetItemType()
        {
            return _random.Next(0, _itemTypesCount);
        }
    }
}