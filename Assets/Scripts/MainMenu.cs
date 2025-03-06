using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject helpButton;
    [SerializeField] GameObject quitButton;

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Help()
    {
        helpPanel.SetActive(true);
        startButton.SetActive(false);
        helpButton.SetActive(false);
        quitButton.SetActive(false);
        Debug.Log("Help button clicked");
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
        startButton.SetActive(true);
        helpButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit button clicked");
    }
}
