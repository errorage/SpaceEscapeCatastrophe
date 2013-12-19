using UnityEngine;
using System.Collections;

public class UI_ButtonClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.closeButton = this;
		this.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		World.disableInteractionWindow();
	}
}
