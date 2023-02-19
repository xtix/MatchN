using UnityEngine;

namespace App.Services.Item.ColorGenerator
{
    public interface IItemColorGenerator
    {
        Color GenerateColor(int itemType);
    }
}