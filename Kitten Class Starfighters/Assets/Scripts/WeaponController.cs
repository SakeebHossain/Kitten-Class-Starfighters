using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	private float power = 0;
	public GameObject weapon;
	public Vector2 currentWeaponPosition;
	public bool clickedOn;
	public Vector2 currentMousePosition;
	public Vector2 trajectory;
	public LineRenderer trajectoryLine;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		if (clickedOn) {

			currentWeaponPosition = transform.position;

			inProcessOfThrowingWeapon ();
			
		}
		
	}

	/*
	 * Given a weapon and location of the player that summoned it, creates a clone of that weapon over the players head 
	*/
	public void createWeapon (GameObject weapon, Vector2 currentObjectPosition) {
		
		currentWeaponPosition = currentObjectPosition + new Vector2 (0, 2);
		weapon = Instantiate(weapon, currentWeaponPosition, Quaternion.identity);
	
	}

	public void inProcessOfThrowingWeapon () {
		// Grabs the current position of the mouse in World Space.
		currentMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		// Find the difference between the two points.
		trajectory = currentMousePosition - currentWeaponPosition;

		// Put a limit of the maximum line size.
		if (trajectory.magnitude > 2) {
			trajectory = 2 * trajectory.normalized;
		}

		// Draw trajectory line.
		Debug.Log(PlayerController.state);
		trajectoryLine.SetPosition (0, currentWeaponPosition);
		trajectoryLine.SetPosition (1, currentWeaponPosition - 2 * trajectory);
	}
		

	void OnMouseDown() {
		Debug.Log ("clicked wapon");
		clickedOn = true;
		trajectoryLine.enabled = true;
	}

	void OnMouseUp() {
		clickedOn = false;
		trajectoryLine.enabled = false;
		power = -150 * trajectory.magnitude;
		weapon.AddComponent<Rigidbody2D> ();
		weapon.GetComponent<Rigidbody2D>().AddForce (trajectory * power);
	}
}
