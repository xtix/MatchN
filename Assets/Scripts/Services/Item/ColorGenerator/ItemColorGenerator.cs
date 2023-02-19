using System;
using UnityEngine;

namespace App.Services.Item.ColorGenerator
{
    public class ItemColorGenerator : IItemColorGenerator
    {
        private readonly int _itemTypesCount;

        public ItemColorGenerator(int itemTypesCount)
        {
            _itemTypesCount = itemTypesCount;
        }

        public Color GenerateColor(int itemType)
        {
            if (itemType < 0 || itemType >= _itemTypesCount)
                throw new ArgumentOutOfRangeException(
                    nameof(itemType),
                    $"Item type must be positive and lower than {_itemTypesCount}, but got {itemType}."
                );
            
            float colorComponentValue = Mathf.InverseLerp(0, _itemTypesCount - 1, itemType);

            return new Color(colorComponentValue, Mathf.Pow(colorComponentValue, 2), 1f - colorComponentValue);
        }
    }
}