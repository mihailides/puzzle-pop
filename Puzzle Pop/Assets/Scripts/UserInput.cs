using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
			for (int i = 0; i < hits.Length; i++) {
				// Destroy(hits[i].transform.gameObject);
				// Check if the piece is positioned at the right or left
				bool is_left = hits[i].transform.position.x < transform.position.x;
				hits[i].collider.gameObject.GetComponent<BoardPiece>().FlipPosition(is_left);
				Debug.Log("Swap!");
			}
		}
	}

	void SwapBlocks() {
		// Swapping blocks..
	}
}
