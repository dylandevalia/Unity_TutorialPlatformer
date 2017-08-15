using UnityEngine;

public class DestoryCompletedParticle : MonoBehaviour {
	private ParticleSystem particles;

	void Start() {
		particles = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update() {
		if (!particles.isPlaying) {
			Destroy(gameObject);
		}
	}

	private void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
