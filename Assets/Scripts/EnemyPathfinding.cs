using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rigidBody;
    private Vector2 movePos;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rigidBody.MovePosition(rigidBody.position + movePos * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPos) {
        movePos = targetPos;
    }
}
