using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour {
	public GameObject boardpiece;
	public string type;
	
	private bool isAtTop;

	// TODO deal later
	bool isVisible = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void FlipPosition(bool moveRight) {
		// Check if it's the left or right piece to be swapped
		if (moveRight) {
			transform.position += new Vector3(1, 0, 0);
		} else {
			transform.position += new Vector3(-1, 0, 0);
		}
	}

	public void SetType(string colour) {
		type = colour;
	}
}

