using UnityEngine;
using System.Collections;

public class UI_Notice : MonoBehaviour {

	bool active = false;
	int framesLeft = 0;

	// Use this for initialization
	void Start () {
		World.uiNotice = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
			framesLeft--;
			if(framesLeft == 0){
				guiText.enabled = false;
			}
		}
	}

	//Displays the message 'message' for 'time' frames.
	public void displayMessage(string message, int time){
		active = true;
		guiText.enabled = true;
		guiText.text = message;
		framesLeft = time;
	}
}
