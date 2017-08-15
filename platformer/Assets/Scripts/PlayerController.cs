using UnityEngine;

public class PlayerController : MonoBehaviour {
	public bool isAlive = true;

	// Movement variables
	public float movementSpeed;
	private float moveVel;
	public float jumpHeight;

	// Double jump
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;
	private bool doubleJumped;

	// Firing
	public Transform firepoint;
	public GameObject throwingStar;

	// Animation
	private Animator animator;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
	}

	// Update is called on a fixed time frame - use for physics
	void FixedUpdate() {
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update() {
		Vector2 vel = GetComponent<Rigidbody2D>().velocity;

		animator.SetBool("onGround", onGround);
		if (onGround) { doubleJumped = false; }

		// Pressed space to jump
		if (Input.GetKeyDown(KeyCode.Space)) {
			// If not on the ground and used double jump - don't jump again
			if (!(!onGround && doubleJumped)) {
				if (!onGround && !doubleJumped) { doubleJumped = true; }
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			}
		}

		moveVel = 0f;

		// Movement
		if (Input.GetKey(KeyCode.A)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVel = -movementSpeed;
		}
		if (Input.GetKey(KeyCode.D)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVel = movementSpeed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVel, GetComponent<Rigidbody2D>().velocity.y);

		// Firing
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			Instantiate(throwingStar, firepoint.position, firepoint.rotation);
		}

		// Speed for animator
		animator.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		// Flip sprites if facing other direction
		if (GetComponent<Rigidbody2D>().velocity.x > 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (GetComponent<Rigidbody2D>().velocity.x < 0) {
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	// Reset player on death
	public void reset() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}
}
