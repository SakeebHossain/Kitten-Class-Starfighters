using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector2 currentObjectPosition;
	public Vector2 currentMousePosition;
	public bool clickedOn;
	private float power;
	public static string state = "START";  // states are START, VIEWINGMENU, ATTACK, THROW, JUMP.
	public int playerID;
	public Vector2 trajectory;

	public Rigidbody2D player;  // The currently selected player.
	public LineRenderer trajectoryLine;  // The line drawn over a player showing the direction of their jump. 

	public MoveMenu moveMenu;
	public WeaponController weaponController;
	public GameObject weapon;


	// Update is called once per frame.
	void Update () {


		if (clickedOn) {

			currentObjectPosition = transform.position;

			// Open the menu that asks player to select either to jump, attack or cancel.
			if (state == "VIEWINGMENU") {
				// show menu, which will decide the next state: JUMP, ATTACK or CANCEL.

				moveMenu.show ();

			}

			if (state == "ATTACK") {

				// generate item at current location
				weaponController.createWeapon(weapon, currentObjectPosition);
				state = "THROW";
							    
			}

			if (state == "THROW") {
				//wait for player to interact with weapon. Interaction with weapon is 
				//handled in WeaponController
			}
				
			if (state == "JUMP") {

				//Debug.Log((Vector3) currentMousePosition);

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
