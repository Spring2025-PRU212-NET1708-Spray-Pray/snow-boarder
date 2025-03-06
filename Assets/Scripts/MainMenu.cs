using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Replace "GameScene" with the name of your game scene
    }

    public void Help()
    {
        // Implement options menu functionality here
        Debug.Log("Help button clicked");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit button clicked");
    }
}
