using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public Vector2 currentObjectPosition;
	public Vector2 currentMousePosition;
	public Vector2 trajectoryPath;
	public LineRenderer line1;
	public bool clickedOn;

	public Rigidbody2D rb;
	public GameObject go;

	public int power;

	public Color c1 = Color.white;

	void Start() {

		// Initialize the first line.
		go = new GameObject();
		rb = GetComponent<Rigidbody2D> ();

		line1 = go.AddComponent<LineRenderer>();

		line1.startWidth = 0.1f;
		line1.endWidth = 0.1f;

	}

	
	// Update is called once per frame
	void FixedUpdate () {

		if (clickedOn) {

			// Grabs the position of the object according to World Space.
			currentObjectPosition = transform.position;  

			// Grabs the current position of the mouse in World Space.
			currentMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			// Fine the difference between the two points
			trajectoryPath = currentMousePosition - currentObjectPosition;

			if (trajectoryPath.magnitude > 2) {
				trajectoryPath = 2 * trajectoryPath.normalized;
			}

			// Draw trajectory line.
			line1.SetPosition (0, currentObjectPosition);
			line1.SetPosition (1, currentObjectPosition - 2 * trajectoryPath);

		}

	}

	void OnMouseDown() {
		line1.enabled = true;
		clickedOn = true;
	}

	void OnMouseUp() {
		line1.enabled = false;
		clickedOn = false;

		// do jump
		Debug.Log("mouse went up");
		rb.AddForce(trajectoryPath * trajectoryPath.magnitude * -150);
		Debug.Log ("jumped");

	}
}
