using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // deo za movement
    [SerializeField] float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rigidBody;

    // deo za animacije
    private Animator myAnimator;
    private SpriteRenderer player;

    private void Awake() {
        playerControls = new PlayerControls();
        rigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        player = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
        AdjustPlayerFacingDirection();
    }

    private void FixedUpdate() {
        Move();
    }

    private void PlayerInput() {
        // cita inpute u obliku Vector2 varijable
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        // postavljanje vrednosti koje imamo u okviru animatora da detektuje trcanje
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        rigidBody.MovePosition(rigidBody.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x > playerPos.x)
            player.flipX = false;
        else
            player.flipX = true;
    }
}
