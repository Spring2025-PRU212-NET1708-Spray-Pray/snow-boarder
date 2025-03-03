using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject infoPanel;
    public string LevelName;

    private void Start()
    {
        mainPanel.SetActive(true);
        infoPanel.SetActive(false);
    }
    public void PlayGameButton()
    {
        SceneManager.LoadScene(LevelName);
    }
    public void QuitGameButton() 
    {
        Application.Quit();
    }
    public void InfoButton()
    {
        mainPanel.SetActive(false );
        infoPanel.SetActive(true);
    }
    public void BackBtton()
    {
        mainPanel.SetActive(true);
        infoPanel.SetActive(false);
    }

}
