using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	private static Game _instance; 
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
    }

	public void AtTop() {
		if (game_froze != true) {
			game_froze = true;
			Debug.Log("Pieces at top!");
		}
	}

	public void NoLongerTop() {
		if (game_froze != false) {
			game_froze = false;
			Debug.Log("Pieces no longer at top!");
		 }
	}
}
