using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject helpPanel; // Reference to the Help Panel
    [SerializeField] GameObject startButton; // Reference to the Start Button
    [SerializeField] GameObject helpButton;
    [SerializeField] GameObject quitButton; // Reference to the Quit Button

    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Replace "GameScene" with the name of your game scene
    }

    public void Help()
    {
        helpPanel.SetActive(true); // Show the Help Panel
        startButton.SetActive(false); // Hide the Start Button
        helpButton.SetActive(false); // Hide the Help Button
        quitButton.SetActive(false); // Hide the Quit Button
        Debug.Log("Help button clicked");
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false); // Hide the Help Panel
        startButton.SetActive(true); // Show the Start Button
        helpButton.SetActive(true); // Show the Help Button
        quitButton.SetActive(true); // Show the Quit Button
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit button clicked");
    }
}
