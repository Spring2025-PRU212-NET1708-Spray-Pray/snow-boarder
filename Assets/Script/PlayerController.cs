using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �� "Class/Member Variables" 
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector;


    // �� "Serialize Field" 
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float finishSpeed = 5f;

    bool canMove = true;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
    }

    public void SetFinishSpeed()
    {
        surfaceEffector.speed = finishSpeed;
    }

    void Update()
    {
        if (canMove)
        {
            RespondToBoost();
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            RotatePlayer();
            AdjustPhysicsBasedOnSlope();

            // Adjust drag based on velocity for smoother movement
            rb2d.linearDamping = Mathf.Clamp(1f - Mathf.Abs(rb2d.linearVelocity.x) / 10f, 0.1f, 1f);
            AdjustDragOnSlope();
        }
    }


    public void DisableControls()
    {
        canMove = false;
    }
    void RotatePlayer()
    {
        float turnDirection = Input.GetAxis("Horizontal");
        rb2d.AddTorque(-turnDirection * torqueAmount);

        // Clamp rotation speed
        rb2d.angularVelocity = Mathf.Clamp(rb2d.angularVelocity, -100f, 100f);
    }
    void RespondToBoost()
    {
        float targetSpeed = Input.GetKey(KeyCode.LeftShift) ? boostSpeed : baseSpeed;
        surfaceEffector.speed = Mathf.Lerp(surfaceEffector.speed, targetSpeed, Time.deltaTime * 5f);
    }
    void AdjustPhysicsBasedOnSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            rb2d.gravityScale = 1f + slopeAngle / 45f; // Increase gravity on steeper slopes
        }
    }
    void AdjustDragOnSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            rb2d.linearDamping = Mathf.Clamp(1f - slopeAngle / 45f, 0.1f, 1f); // More drag on flatter surfaces
        }
    }
}