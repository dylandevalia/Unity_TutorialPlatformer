using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	public LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>(); //GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			lm.respawnPlayer();
		}
	}
}
