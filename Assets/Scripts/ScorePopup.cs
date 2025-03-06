using UnityEngine;
using TMPro;
using System.Collections;

public class ScorePopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] float displayDuration = 1f; // Duration to display the popup
    [SerializeField] Vector3 offsetRange = new Vector3(1, 1, 0); // Range for random offset
    [SerializeField] float fadeDuration = 0.5f; // Duration for the fade-out animation

    private void Start()
    {
        scoreText.gameObject.SetActive(false); // Hide the popup initially
    }

    public void ShowScore(int score, Vector3 position)
    {
        scoreText.text = "+" + score.ToString();
        Vector3 randomOffset = new Vector3(
            Random.Range(-offsetRange.x, offsetRange.x),
            Random.Range(-offsetRange.y, offsetRange.y),
            0
        );
        transform.position = position + randomOffset; 
        scoreText.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color originalColor = scoreText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            scoreText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        scoreText.gameObject.SetActive(false);
        scoreText.color = originalColor; // Reset the color for the next use
    }
}

