
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Components")]
    private CoyoteTime coyoteTime = new CoyoteTime();
    private JumpBuffer jumpBuffer = new JumpBuffer();
    private JumpController jumpController = new JumpController();
    private CrawlController crawlController = new CrawlController();

    [Header("Ground Check")]
    [SerializeField] private Transform groundPoint;
    [SerializeField] private float checkRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;
    [Header("Jump")]
    [SerializeField] private float jumpForce = 12f;

    [Tooltip("Множитель вертикальной скорости при отпускании прыжка")]
    [Range(0f, 1f)]
    [SerializeField] private float jumpCutMultiplier = 0.45f;
    private bool IsGrounded;

    private Rigidbody2D rb;
    private CapsuleCollider2D collider2D;
    private float moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CapsuleCollider2D>();
        jumpController.Init(jumpCutMultiplier, jumpForce, rb);
    }

    private void Update()
    {
        // Горизонтальное управление
        moveInput = Input.GetAxisRaw("Horizontal");

        // Регистрируем нажатие прыжка
        if (Input.GetButtonDown("Jump"))
        {
            jumpBuffer.RegisterInput();
        }

        Ground();

        // Отпускание кнопки обрезает высоту прыжка
        if (Input.GetButtonUp("Jump"))
        {
            jumpController.CutJump();
        }

        jumpBuffer.Tick(Time.deltaTime);
        coyoteTime.Tick(IsGrounded, Time.deltaTime);

        // Выполняем сохранённый прыжок,
        // если персонаж стоит на земле
        // или ещё доступно окно Coyote Time
        if (jumpBuffer.HasBufferedJump && (IsGrounded || coyoteTime.CanJump))
        {
            jumpController.PerformJump();
            jumpBuffer.Consume();
            coyoteTime.Consume();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveInput * PlayerMove.singltoneMove.Speed();
        rb.velocity = velocity;
    }

    private void Ground()
    {
        IsGrounded = Physics2D.OverlapCircle(
            groundPoint.position,
            checkRadius,
            groundLayer);
    }
}
