using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI highScoreText;
        PlayerController playerController;

        void Start()
        {
            playerController = FindFirstObjectByType<PlayerController>();
            highScoreText.text = "High Score: " + playerController.LoadHighScore().ToString("0");
        }

        void Update()
        {
            scoreText.text = "Score: " + playerController.GetScore().ToString("0");
        }
    }
}
