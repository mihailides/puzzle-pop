using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	private List<string> colours = new List<string>(new string[] { "Yellow", "Purple", "Red", "Green", "Blue" });
	private GameObject[,] board_pieces = new GameObject[row_numbers, starting_column_numbers];
	private static int row_numbers = 11;
	private static int starting_column_numbers = 5;

	float[,] move = new float[row_numbers, starting_column_numbers];
	public float moveSpeed = 1;

	public int row_start_pos = 4;
	public int column_start_pos = 11;

	// Use this for initialization
	void Start () {
		CreateBlocks();
		Game.Instance.StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		MoveBlocks();
		DeleteIfCombo();
	}

	public void CreateBlocks() {
		for (int j = 0; j < starting_column_numbers; j++) {
			for (int i = 0; i < row_numbers; i++) {
				string type = colours[Random.Range(0, colours.Count)];
				string prefab = type + "_piece";

				GameObject piece = Instantiate(Resources.Load("Prefabs/" + prefab)) as GameObject;
				piece.GetComponent<BoardPiece>().SetType(type);
				piece.transform.position = new Vector3(row_start_pos + i, -8  + j, 0); 
				board_pieces[i, j] = piece;
				move[i, j] = 0;
			}
		}
	}

	public void MoveBlocks() {
		// Debug.Log(board_pieces);
		for (int j = 0; j < starting_column_numbers; j++) {
			for (int i = 0; i < row_numbers; i++) {
				if (board_pieces[i, j] != null) {
					if (Game.Instance.HasGameStarted() && board_pieces[i, j].transform.position.y < 8) {
						if (Time.time - move[i, j] >= moveSpeed) {
							board_pieces[i, j].transform.position += new Vector3(0, 1, 0);
							move[i, j] = Time.time;
						}
					}
				}
			}
		}
	}

	public void DeleteIfCombo() {
		for (int j = 0; j < starting_column_numbers; j++) {
			for (int i = 0; i < row_numbers; i++) {
				if (board_pieces[i, j] != null) {
					RaycastHit2D hit_left = Physics2D.Raycast(board_pieces[i, j].transform.position, Vector2.left);
					
					if (hit_left != null && 
					hit_left.collider != null && 
					hit_left.collider != board_pieces[i, j].GetComponent<Collider>() && 
					hit_left.collider.gameObject.GetComponent<BoardPiece>().type == board_pieces[i, j].GetComponent<BoardPiece>().type) {

						RaycastHit2D hit_right = Physics2D.Raycast(board_pieces[i, j].transform.position, Vector2.right);
						if (hit_right != null && 
						hit_right.collider != null && 
						hit_right.collider != board_pieces[i, j].GetComponent<Collider>() && 
						hit_right.collider.gameObject.GetComponent<BoardPiece>().type == board_pieces[i, j].GetComponent<BoardPiece>().type) {
							Destroy(hit_right.collider.gameObject);
							Destroy(hit_left.collider.gameObject);
							// Probably not gona destroy the instantianted object who knows
							// Destroy(board_pieces[i, j]);

							// board_pieces[i, j] = null;
						}
					}
				}
			}
		}		
	}
		// RaycastHit2D hit_left = Physics2D.Raycast(originalPos.position, Vector2.left);
		// // todo: does not equal our collider
		// if (hit_left != null && hit_left.collider != null && hit_left.collider != hit_left.collider.gameObject.GetComponent<BoardPiece>().type == type) {
			
		// 	RaycastHit2D hit_right = Physics2D.Raycast(originalPos.position, Vector2.right);
		// 	if (hit_right != null && hit_right.collider != null && hit_right.collider.gameObject.GetComponent<BoardPiece>().type == type) {
		// 		// Debug.Log("Right block: x-" + hit_right.transform.position.x + " y-" + hit_right.transform.position.y + " " + hit_right.collider.gameObject.GetComponent<BoardPiece>().type + " Left block: x-" + hit_left.transform.position.x + " y-" + hit_left.collider.gameObject.transform.position.y + " " +  hit_left.collider.gameObject.GetComponent<BoardPiece>().type
		// 		// + " Middle block: x-" + originalPos.position.x + " y-" + originalPos.position.y + " " );
		// 		// Debug.Log("3 or more found!");
		// 		Destroy(board_piece);
		// 		Destroy(hit_right.collider.gameObject);
		// 		Destroy(hit_left.collider.gameObject);
		// 	}
		// }

}
