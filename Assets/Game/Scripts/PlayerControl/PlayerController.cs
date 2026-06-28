using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;

    private Vector2 _movement;
    private Rigidbody2D _rb;
    private EternalGroveInputActions _inputActions;
    
    private static readonly int IsMovingRightHash = Animator.StringToHash("isMovingRight");
    private static readonly int IsMovingLeftHash = Animator.StringToHash("isMovingLeft");
    private static readonly int IsMovingUpHash = Animator.StringToHash("isMovingUp");
    private static readonly int IsMovingDownHash = Animator.StringToHash("isMovingDown");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _inputActions = new EternalGroveInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * (speed * Time.fixedDeltaTime));
    }

    private void Update()
    {
        _movement = _inputActions.Player.Move.ReadValue<Vector2>();
        UpdateAnimationParameters();
    }

    private void UpdateAnimationParameters()
    {
        if (animator == null) return;

        animator.SetBool(IsMovingRightHash, false);
        animator.SetBool(IsMovingLeftHash, false);
        animator.SetBool(IsMovingUpHash, false);
        animator.SetBool(IsMovingDownHash, false);

        if (_movement != Vector2.zero)
        {
            if (Mathf.Abs(_movement.x) > Mathf.Abs(_movement.y))
            {
                animator.SetBool(_movement.x > 0 ? IsMovingRightHash : IsMovingLeftHash, true);
            }
            else
            {
                animator.SetBool(_movement.y > 0 ? IsMovingUpHash : IsMovingDownHash, true);
            }
        }
    }
}
