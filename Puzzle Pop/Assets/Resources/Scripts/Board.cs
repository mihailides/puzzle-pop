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
		DeleteCombos(FindCombos());
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

	public List<GameObject> FindCombos() {
		List<GameObject> to_delete = new List<GameObject>();
		for (int j = 0; j < starting_column_numbers; j++) {
			for (int i = 0; i < row_numbers; i++) {
				if (board_pieces[i, j] != null) {
					// Bad, trying to find a better way. Can't turn queries off yet.
					board_pieces[i, j].G etComponent<Collider2D>().enabled = false; 

					RaycastHit2D hit_left = Physics2D.Raycast(board_pieces[i, j].transform.position, Vector2.left, 1);

					if (hit_left != null && hit_left.collider != null && hit_left.collider.gameObject.GetComponent<BoardPiece>().type == board_pieces[i, j].GetComponent<BoardPiece>().type) {
						RaycastHit2D hit_right = Physics2D.Raycast(board_pieces[i, j].transform.position, Vector2.right, 1);

						if (hit_right != null && hit_right.collider != null && hit_right.collider.gameObject.GetComponent<BoardPiece>().type == board_pieces[i, j].GetComponent<BoardPiece>().type) {

							to_delete.Add(hit_right.collider.gameObject);
							to_delete.Add(hit_left.collider.gameObject);
							to_delete.Add(board_pieces[i, j]);
						}
					}
					// Check vertical combo
					RaycastHit2D hit_up = Physics2D.Raycast(board_pieces[i, j].transform.position, Vector2.up, 1);
					
					if (hit_up != null && hit_up.collider != null &&  hit_up.collider.gameObject.GetComponent<BoardPiece>().type == board_pieces[i, j].GetComponent<BoardPiece>().type) {
						RaycastHit2D hit_down = Physics2D.Raycast(board_pieces[i, j].transform.position, Vector2.down, 1);

						if (hit_down != null && hit_down.collider != null && hit_down.collider.gameObject.GetComponent<BoardPiece>().type == board_pieces[i, j].GetComponent<BoardPiece>().type) {
							
							to_delete.Add(hit_up.collider.gameObject);
							to_delete.Add(hit_down.collider.gameObject);
							to_delete.Add(board_pieces[i, j]);
						}
					}

					// Turn collider back on.
					if (board_pieces[i, j]) {
						board_pieces[i, j].GetComponent<Collider2D>().enabled = true; 
					}
				}
			}
		}
		return to_delete;	
	}	

	public void DeleteCombos(List<GameObject> to_delete) {
		foreach(GameObject block in to_delete) {
			if (block) {
				Destroy(block);				
			}
		}
	}
}
