using UnityEngine;
using System.Collections;

public class UI_Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.name == "UISpeed"){
			World.uiSpeed = this;
		}else{
			World.uiScore = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
