using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrailFX;
    CapsuleCollider2D snowboard;
    CircleCollider2D head;

    private void Start()
    {
        snowboard = GetComponent<CapsuleCollider2D>();
        head = GetComponent<CircleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.otherCollider == snowboard) dustTrailFX.Play();
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")  dustTrailFX.Stop();
    }
}
