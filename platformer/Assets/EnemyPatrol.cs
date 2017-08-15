using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
	// Movement
	public float moveSpeed;
	public bool moveRight;

	// Bounce off walls & edges
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	public Transform edgeCheck;
	private bool onEdge;

	// Death particles
	[SerializeField]
	private GameObject particle_death;

	private void Update() {
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		onEdge = !Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || onEdge) { moveRight = !moveRight; }

		// Flip sprites if facing other direction
		if (moveRight) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else {
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveRight ? moveSpeed : -moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	public void onDeath() {
		Instantiate(particle_death, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
