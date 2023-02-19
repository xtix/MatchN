using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Config.Windows
{
    [Serializable]
    public class WindowsConfig
    {
        [SerializeField] private List<Window> _windowList;

        public List<Window> WindowList => _windowList;
    }
}