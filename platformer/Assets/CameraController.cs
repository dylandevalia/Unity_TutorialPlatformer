using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private PlayerController pc;
	public Vector3 camOffset;
	public bool isFollowing;

	private void Start() {
		pc = FindObjectOfType<PlayerController>();
		isFollowing = true;
	}

	private void Update() {
		if (isFollowing) {
			transform.position = new Vector3(
				pc.transform.position.x + camOffset.x,
				pc.transform.position.y + camOffset.y,
				pc.transform.position.z + camOffset.z
			);
		}
	}
}
