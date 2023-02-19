using System;
using App.Config.Item;
using UnityEngine;

namespace App.Config
{
    [Serializable]
    public class GameConfig
    {
        private const int MinItemTypesCount = 2;
        private const int MinMatchCount = 2;

        [SerializeField] private Board.Board _board;
        [SerializeField, Min(MinItemTypesCount)] private int _itemTypesCount;
        [SerializeField, Min(MinMatchCount)] private int _matchCount;
        [SerializeField] private ItemAnimation _itemAnimation;

        public Board.Board Board => _board;
        public int ItemTypesCount => _itemTypesCount;
        public int MatchCount => _matchCount;
        public ItemAnimation ItemAnimation => _itemAnimation;
    }
}