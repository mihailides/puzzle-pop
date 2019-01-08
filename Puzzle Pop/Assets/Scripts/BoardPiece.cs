using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour {
	float move = 0;
	public float moveSpeed = 1;
	
	private bool isAtTop;

	// TODO deal later
	bool isVisible = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 8) {
			if (Time.time - move >= moveSpeed) {
				transform.position += new Vector3(0, 1, 0);
				move = Time.time;
			}
		} else {
			// Top reached! Send message to freeze all blocks
			isAtTop = true;
			Game.Instance.AtTop();
		}
	}

	public void FlipPosition(bool moveRight) {
		// Check if it's the left or right piece to be swapped
		if (moveRight) {
			transform.position += new Vector3(1, 0, 0);
		} else {
			transform.position += new Vector3(-1, 0, 0);
		}
	}
}

