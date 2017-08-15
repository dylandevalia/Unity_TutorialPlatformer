using UnityEngine;

public class ThrowingStarController : MonoBehaviour {
	public float speed;
	public PlayerController pc;

	[SerializeField]
	private GameObject particle_bash;

	private void Start() {
		pc = FindObjectOfType<PlayerController>();

		speed *= (pc.transform.localScale.x < 0) ? -1 : 1;
	}

	private void Update() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Hostile") {
			collision.GetComponent<EnemyPatrol>().onDeath();
		}

		Instantiate(particle_bash, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
