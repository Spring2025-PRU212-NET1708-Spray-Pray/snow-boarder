using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 4495f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float scoreIncrement = 1f; // Score increment per second
    [SerializeField] float rotationScoreIncrement = 10f; // Score increment for a full rotation

    Rigidbody2D myRB2D;
    SurfaceEffector2D surfaceEffector;
    bool canMove = true;
    float playerScore = 0f;
    float previousRotation = 0f; // Track the previous rotation angle
    float totalRotation = 0f; // Track the total rotation

    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
        surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
        LoadHighScore();
        previousRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            Boost();
            UpdateScore();
            CheckFullRotation();

            // !!! only for developement
            ResetHighScore();
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

    void CheckFullRotation()
    {
        float currentRotation = transform.eulerAngles.z;
        float rotationDelta = Mathf.DeltaAngle(previousRotation, currentRotation);
        totalRotation += rotationDelta;
        previousRotation = currentRotation;

        if (Mathf.Abs(totalRotation) >= 360f)
        {
            playerScore += rotationScoreIncrement;
            totalRotation = 0f;
            Debug.Log("Full Rotation! Score: " + playerScore);
        }
    }

    public void DisableControls()
    {
        canMove = false;
        SaveHighScore();
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
