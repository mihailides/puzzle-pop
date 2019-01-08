using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	private List<string> colours = new List<string>(new string[] { "Yellow", "Purple", "Red", "Green", "Blue" });
	private static int row_numbers = 11;
	private static int starting_column_numbers = 5;

	// Use this for initialization
	void Start () {
		Debug.Log("Starting board..");
		int row_start_pos = 4;
		int column_start_pos = 11;
		for (int j = 0; j < starting_column_numbers; j++) {
			for (int i = 0; i < row_numbers; i++) {
				string type = colours[Random.Range(0, colours.Count)];
				string prefab = type + "_piece";

				GameObject piece = Instantiate(Resources.Load("Prefabs/" + prefab)) as GameObject;
				piece.GetComponent<BoardPiece>().SetType(type);
				piece.transform.position = new Vector3(row_start_pos + i, -8  + j, 0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
