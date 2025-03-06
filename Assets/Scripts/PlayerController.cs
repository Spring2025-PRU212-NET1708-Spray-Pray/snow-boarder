using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 4495f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float scoreIncrement = 1f; // Score increment per second
    [SerializeField] float rotationScoreIncrement = 10f; // Score increment for a full rotation
    [SerializeField] ScorePopup scorePopup; // Reference to the ScorePopup script

    Rigidbody2D myRB2D;
    SurfaceEffector2D surfaceEffector;
    bool canMove = true;
    float playerScore = 0f;
    float previousRotation = 0f; // Track the previous rotation angle
    float totalRotation = 0f; // Track the total rotation

    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
        surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
        LoadHighScore(); // Load the score when the game starts
        previousRotation = transform.eulerAngles.z; // Initialize previous rotation
        ResetHighScore(); // Reset the high score for testing purposes
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            Boost();
            UpdateScore();
            CheckFullRotation();
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRB2D.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRB2D.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    public void UpdateScore()
    {
        playerScore += scoreIncrement * Time.deltaTime;
        //Debug.Log("Score: " + playerScore);
    }

    void CheckFullRotation()
    {
        float currentRotation = transform.eulerAngles.z;
        float rotationDelta = Mathf.DeltaAngle(previousRotation, currentRotation);
        totalRotation += rotationDelta;
        previousRotation = currentRotation;

        if (Mathf.Abs(totalRotation) >= 360f)
        {
            playerScore += rotationScoreIncrement;
            totalRotation = 0f; // Reset the rotation counter
            Debug.Log("Position: " + transform.position);
            scorePopup.ShowScore((int)rotationScoreIncrement, transform.position); // Show the score popup next to the player
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Rock"))
    //    {
    //        GameOver();
    //    }
    //}

    //void GameOver()
    //{
    //    canMove = false;
    //    SaveHighScore(); // Save the highest score when the game is over
    //    Debug.Log("Game Over! Final Score: " + playerScore);
    //    // Add additional game-over logic here (e.g., display game-over UI, restart the game, etc.)
    //}

    public void DisableControls()
    {
        canMove = false;
        SaveHighScore(); // Save the highest score when controls are disabled
    }

    public float GetScore()
    {
        return playerScore;
    }

    public void SaveHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", playerScore);
            PlayerPrefs.Save();
        }
    }

    public float LoadHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore", 0f);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.Save();
        Debug.Log("High Score has been reset.");
    }
}
