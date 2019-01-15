using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
	float move = 0;
	public float moveSpeed = 1;

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
		}
		CheckUserInput();
	}

	void CheckUserInput() {
		if  (Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.position += new Vector3(1, 0, 0);
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1, 0, 0);
		} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.position += new Vector3(0, 1, 0);
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			transform.position += new Vector3(0, -1, 0);
		} else if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.Space))) {
			RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
			for (int i = 0; i < hits.Length; i++) {
				// Check if the piece is positioned at the right or left
				bool is_left = hits[i].transform.position.x < transform.position.x;
				hits[i].collider.gameObject.GetComponent<BoardPiece>().FlipPosition(is_left);
			}
		}
	}

	void SwapBlocks() {
		// Swapping blocks..
	}
}
