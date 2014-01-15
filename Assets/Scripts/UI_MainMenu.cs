using UnityEngine;
using System.Collections;

public class UI_MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.uiMainMenu = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Application.LoadLevel (0);
	}
}
