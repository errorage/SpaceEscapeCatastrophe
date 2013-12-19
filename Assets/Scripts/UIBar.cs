using UnityEngine;
using System.Collections;

public class UIBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.name == "UIBarHealth"){
			World.uiBarHealth = this;
		}else{
			World.uiBarOxy = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
