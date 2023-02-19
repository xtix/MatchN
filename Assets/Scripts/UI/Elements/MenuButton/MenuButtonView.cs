using UnityEngine;
using UnityEngine.UI;

namespace App.UI.Elements.MenuButton
{
    public class MenuButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public Button Button => _button;
    }
}