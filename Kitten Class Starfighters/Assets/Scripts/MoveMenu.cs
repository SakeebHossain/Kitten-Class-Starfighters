using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMenu : MonoBehaviour {

	public GameObject moveMenu;
	public Button attackButton;
	public Button jumpButton;
	public GameObject cancelMoveMenu;
	public Button cancelButton;

	// Use this for initialization
	void Start () {

		jumpButton.onClick.AddListener (selectJump);
		attackButton.onClick.AddListener (selectAttack);
		cancelButton.onClick.AddListener (show);
		moveMenu.SetActive(false);
		cancelMoveMenu.SetActive(false);
		
	}

	// Update is called once per frame
	public void Update () {
		
	}

	public void show() {

		moveMenu.SetActive(true);
		cancelMoveMenu.SetActive(false);
		
	}

	public void hide() {

		moveMenu.SetActive(false);
		
	}


	public void selectJump() {

		hide ();
		cancelMoveMenu.SetActive(true);
		PlayerController.state = "JUMP";

	}

	public void selectAttack() {
		
		hide ();
		cancelMoveMenu.SetActive(true);
		PlayerController.state = "ATTACK";

	}
}
