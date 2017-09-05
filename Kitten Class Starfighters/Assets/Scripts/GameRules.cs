using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {

	public static int PlayerTurn;  // A flag that keeps track of which player's turn it is.

	// Use this for initialization
	void Start () {

		PlayerTurn = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/* 
	 * A function that ends the players turn.
	 */
	void endTurn() {
		PlayerTurn = (PlayerTurn + 1) % 2;  // This set PlayerTurn to 1 if it is 0, and 0 if it 1.
	}

	/* 
	 * Returns true if it is the currently the players turn, false otherwise. 
	*/
	public static bool checkTurn(int playerID) {
		if (PlayerTurn == playerID)
			return true;
		return false;
	}
}
