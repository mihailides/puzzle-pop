using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
	float move = 0;
	public float moveSpeed = 1;
	// TODO deal later
	bool isVisible = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - move >= moveSpeed) {
			transform.position += new Vector3(0, 1, 0);
			move = Time.time;
		}
	}
}
