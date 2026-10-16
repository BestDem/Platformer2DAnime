
using UnityEngine;

public class JumpBuffer
{
    [SerializeField, Min(0f)]
    private float bufferDuration = 0.12f;

    private float timer;

    public bool HasBufferedJump => timer > 0f;

    public void RegisterInput()
    {
        timer = bufferDuration;
    }

    public void Tick(float deltaTime)
    {
        timer = Mathf.Max(0f, timer - deltaTime);
    }

    public void Consume()
    {
        timer = 0f;
    }
}
