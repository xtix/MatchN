using System;
using UnityEngine;

namespace App.Config.Board
{
    [Serializable]
    public class Board
    {
        private const int MinSideSize = 3;

        [SerializeField, Min(MinSideSize)] private int _xSize;
        [SerializeField, Min(MinSideSize)] private int _ySize;

        public int XSize => _xSize;
        public int YSize => _ySize;
    }
}