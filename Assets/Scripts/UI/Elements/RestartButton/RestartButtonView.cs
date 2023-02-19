using UnityEngine;
using UnityEngine.UI;

namespace App.UI.Elements.RestartButton
{
    public class RestartButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public Button Button => _button;
    }
}