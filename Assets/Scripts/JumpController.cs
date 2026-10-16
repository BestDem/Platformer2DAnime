
using UnityEngine;

public class JumpController
{
    private float jumpForce;
    private float jumpCutMultiplier;

    private Rigidbody2D rb;

    public void Init(float jumpM, float jumpForceN, Rigidbody2D r)
    {
        jumpCutMultiplier = jumpM;
        jumpForce = jumpForceN;
        rb = r;
    }

    public void PerformJump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
    }

    public void CutJump()
    {
        if (rb.velocity.y > 0f)
        {
            Vector2 velocity = rb.velocity;
            velocity.y *= jumpCutMultiplier;
            rb.velocity = velocity;
        }
    }
}
