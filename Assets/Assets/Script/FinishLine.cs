using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2f;
    [SerializeField] ParticleSystem finishFX;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            finishFX.Play();
            GetComponent<AudioSource>().Play();
            FindFirstObjectByType<PlayerController>().DisableControls();
            FindFirstObjectByType<PlayerController>().SetFinishSpeed();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene()
    {
        Debug.Log("Mutulici a terminat");
        SceneManager.LoadScene(0); 
    }
}
