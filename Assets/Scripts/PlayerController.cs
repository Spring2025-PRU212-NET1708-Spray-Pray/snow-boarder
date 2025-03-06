using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 4495f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float scoreIncrement = 1f; // Score increment per second

    Rigidbody2D myRB2D;
    SurfaceEffector2D surfaceEffector;
    bool canMove = true;
    float playerScore = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
        surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
        LoadHighScore(); // Load the score when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            Boost();
            UpdateScore();
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
        Debug.Log("Score: " + playerScore);
    }

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
}
