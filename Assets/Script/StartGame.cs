using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class StartGame : MonoBehaviour
{
    public string LevelName;
    public AudioMixer AudioMixer;
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }
}
