
using UnityEngine;

public class CoyoteTime
{
    private float coyoteDuration = 0.12f;

    private float timer;
    private bool wasGrounded;
    private bool jumpConsumed;

    public bool CanJump => timer > 0f;

    public void Tick(bool isGrounded, float deltaTime)
    {
        if (isGrounded)
        {
            if (!wasGrounded)
            {
                jumpConsumed = false;
            }

            if (!jumpConsumed)
            {
                timer = coyoteDuration;
            }
            else
            {
                timer = 0f;
            }
        }
        else
        {
            timer -= deltaTime;
        }

        wasGrounded = isGrounded;
    }

    public void Consume()
    {
        timer = 0f;
        jumpConsumed = true;
    }
}
