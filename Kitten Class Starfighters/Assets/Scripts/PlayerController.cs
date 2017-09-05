using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public Vector2 currentObjectPosition;
	public Vector2 currentMousePosition;
	public Vector2 trajectory;
	public bool clickedOn;
	public float power;
	public static string state = "START";  // states are START, VIEWINGMENU, ATTACK, JUMP.
	public int playerID = 100;

	public Rigidbody2D player;  // The currently selected player.
	public LineRenderer trajectoryLine;  // The line drawn over a player showing the direction of their jump. 

	public MoveMenu moveMenu;


	// Update is called once per frame.
	void FixedUpdate () {


		if (clickedOn) {

			Debug.Log (playerID);

			// Open the menu that asks player to select either to jump, attack or cancel.
			if (state == "VIEWINGMENU") {
				// show menu, which will decide the next state: JUMP, ATTACK or CANCEL.

				moveMenu.show ();

			}

			if (state == "ATTACK") {
							    
			}
				
				
			if (state == "JUMP") {



				// Grabs the position of the object according to World Space.
				currentObjectPosition = transform.position; 

				// Grabs the position of the object according to World Space.
				currentObjectPosition = transform.position;  

				// Grabs the current position of the mouse in World Space.
				currentMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

				// Find the difference between the two points.
				trajectory = currentMousePosition - currentObjectPosition;

				// Put a limit of the maximum line size.
				if (trajectory.magnitude > 2) {
					trajectory = 2 * trajectory.normalized;
				}

				// Draw trajectory line.
				trajectoryLine.SetPosition (0, currentObjectPosition);
				trajectoryLine.SetPosition (1, currentObjectPosition - 2 * trajectory);

			}
		}

	}

	void OnMouseDown() {
		
		clickedOn = true;

		// If state is START, that means the player can open the menu.
		if (state == "START") {
			
			state = "VIEWINGMENU";

		}

		if (state == "ATTACK") {
			
		}
			
		if (state == "JUMP") {
			trajectoryLine.enabled = true;
		}

	}

	void OnMouseUp() {

		// Note: state is never START on mouse up.

		clickedOn = false;

		if (state == "ATTACK") {

		}

		if (state == "JUMP") {
			trajectoryLine.enabled = false;


			// Make player jump.
			power = -150 * trajectory.magnitude;
			player.AddForce (trajectory * power);
		}
	}
}
