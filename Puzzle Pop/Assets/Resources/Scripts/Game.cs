using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	private static Game _instance; 
	private static bool game_started = false;
	private bool game_froze = false;

    public static Game Instance { 
		get { 
				return _instance ?? (_instance = new GameObject("Game").AddComponent<Game>()); 
			} 
		}

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    // }

	// public void AtTop() {
	// 	if (game_froze != true) {
	// 		game_froze = true;
	// 		Debug.Log("Pieces at top!");
	// 	}
	// }

	// public void NoLongerTop() {
	// 	if (game_froze != false) {
	// 		game_froze = false;
	// 		Debug.Log("Pieces no longer at top!");
	// 	 }
	// }

	// public void DeleteBlocks(Transform originalPos, string type, GameObject board_piece) {
	// 	RaycastHit2D hit_left = Physics2D.Raycast(originalPos.position, Vector2.left);
	// 	// todo: does not equal our collider
	// 	if (hit_left != null && hit_left.collider != null && hit_left.collider != hit_left.collider.gameObject.GetComponent<BoardPiece>().type == type) {
			
	// 		RaycastHit2D hit_right = Physics2D.Raycast(originalPos.position, Vector2.right);
	// 		if (hit_right != null && hit_right.collider != null && hit_right.collider.gameObject.GetComponent<BoardPiece>().type == type) {
	// 			// Debug.Log("Right block: x-" + hit_right.transform.position.x + " y-" + hit_right.transform.position.y + " " + hit_right.collider.gameObject.GetComponent<BoardPiece>().type + " Left block: x-" + hit_left.transform.position.x + " y-" + hit_left.collider.gameObject.transform.position.y + " " +  hit_left.collider.gameObject.GetComponent<BoardPiece>().type
	// 			// + " Middle block: x-" + originalPos.position.x + " y-" + originalPos.position.y + " " );
	// 			// Debug.Log("3 or more found!");
	// 			Destroy(board_piece);
	// 			Destroy(hit_right.collider.gameObject);
	// 			Destroy(hit_left.collider.gameObject);
	// 		}
	// 	}

		// if (isHorizontal) {
		// 	// Delete block(s) left and right of original
		// 	// TODO: keep checking direction for mroe blocks..generate a score based on how many
		// } else {
		// 	// Delete up and down block(s)
		// 	// TODO: keep checking direction for mroe blocks..generate a score based on how many

		// }
	}

	public void StartGame() {
		game_started = true;
	}

	public void PauseGame() {
		game_started = false;
	}

	public void EndGame() {
		game_started = false;
	}

	public bool HasGameStarted() {
		return game_started;
	}
}
