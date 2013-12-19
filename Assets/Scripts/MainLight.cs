using UnityEngine;
using System.Collections;

public class MainLight : MonoBehaviour {
	
	public string lightName = "";
	bool turningOn = false;
	int turningOnProgress = 0;
	
	// Use this for initialization
	void Start () {
		if(lightName == "captain"){
			World.mainLightCaptain = this;
		}else if (lightName == "left"){
			World.mainLightLeft = this;
		}else{
			World.mainLightRight = this;
		}
		light.intensity = 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
		if(turningOn){
			turningOnProgress++;
			
			switch(turningOnProgress){
			case 5:
				this.light.enabled = true;
				break;
			case 35:
				this.light.enabled = false;
				break;
			case 40:
				this.light.enabled = true;
				break;
			case 95:
				this.light.enabled = false;
				break;
			case 100:
				this.light.enabled = true;
				break;
			case 115:
				this.light.enabled = false;
				break;
			case 118:
				this.light.enabled = true;
				turningOn = false;
				break;
			}
		}
	}
	
	public void turnOnProcess(){
		turningOn = true;
		turningOnProgress = 0;
	}
}
