using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMenu : MonoBehaviour {

	public GameObject moveMenu;
	public Button attackButton;
	public Button jumpButton;

	// Use this for initialization
	void Start () {

		moveMenu.SetActive(false);
		jumpButton.onClick.AddListener (selectJump);
		
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void show() {

		moveMenu.SetActive(true);
		PlayerController.state = "JUMP";
		
	}

	public void hide() {

		moveMenu.SetActive(false);
		
	}

	public void selectJump() {

		moveMenu.SetActive(false);


		
	}

	public void selectAttack() {


		
	}
}
