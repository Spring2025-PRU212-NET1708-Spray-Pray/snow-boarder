using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
	public class ScoreDisplay : MonoBehaviour
	{
        [SerializeField] TextMeshProUGUI scoreText;
        PlayerController playerController;

        void Start()
        {
            playerController = FindFirstObjectByType<PlayerController>();
        }

        void Update()
        {
            scoreText.text = "Score: " + playerController.GetScore().ToString("0");
        }
    }
}