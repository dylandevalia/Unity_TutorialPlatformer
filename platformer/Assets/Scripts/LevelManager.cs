using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject curCheckpoint;
	private PlayerController player;
	private CameraController cam;

	public float respawnDelay;

	// Particles
	public GameObject particle_death;
	public GameObject particle_respawn;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		cam = FindObjectOfType<CameraController>();
	}

	public void respawnPlayer() {
		if (player.isAlive) {
			player.isAlive = false;
			StartCoroutine("co_respawnPlayer");
		}
	}

	public IEnumerator co_respawnPlayer() {
		Debug.Log("Player - die");
		Instantiate(particle_death, player.transform.position, player.transform.rotation);
		player.enabled = false;
		//player.GetComponent<CircleCollider2D>().enabled = false;
		player.GetComponent<Rigidbody2D>().velocity = new Vector2();
		//float gravScale = player.GetComponent<Rigidbody2D>().gravityScale;
		//player.GetComponent<Rigidbody2D>().gravityScale = 0;
		//player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		cam.isFollowing = false;
		ScoreManager.addScore(-50);

		yield return new WaitForSeconds(respawnDelay);

		Debug.Log("Player - respawn");
		player.enabled = true;
		//player.GetComponent<CircleCollider2D>().enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		//player.GetComponent<Rigidbody2D>().gravityScale = gravScale;
		player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		cam.isFollowing = true;
		player.transform.position = curCheckpoint.transform.position;
		player.reset();
		Instantiate(particle_respawn, player.transform.position, player.transform.rotation);
		player.isAlive = true;
	}
}
