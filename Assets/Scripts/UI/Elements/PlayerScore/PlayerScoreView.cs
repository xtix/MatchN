using TMPro;
using UnityEngine;

namespace App.UI.Elements.PlayerScore
{
    public class PlayerScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetScore(int value)
        {
            _scoreText.SetText(value.ToString());
        }
    }
}