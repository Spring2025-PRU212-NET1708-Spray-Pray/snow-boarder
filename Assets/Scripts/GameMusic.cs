using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
