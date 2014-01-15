using UnityEngine;
using System.Collections;

public class UI_Black : MonoBehaviour {
	
	int fadingOutProgress = 0;
	bool fadingOut = false;
	int fadingInProgress = 0;
	bool fadingIn = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (fadingIn) {
			fadingInProgress++;
			this.guiTexture.color = new Color(0f,0f,0f,0.5f);
			this.guiTexture.guiTexture.color = new Color(0f,0f,0f,0.5f);
			if(fadingInProgress == 90){
				fadingIn = false;
				this.guiTexture.color = new Color(0f,0f,0f,1f);
			}
			Debug.Log (fadingInProgress);
		}
	
	}
	
	public void fadeOut(){
		fadingOutProgress = 0;
		fadingOut = true;
	}
	
	public void fadeIn(){
		fadingInProgress = 0;
		fadingIn = true;
	}
}
