using UnityEngine;
using System.Collections;

public class ThrusterLight : MonoBehaviour {
	
	public string dir = "";
	
	public float flickerProgress = 0;
	
	// Use this for initialization
	void Start () {
		if(dir == "left"){
			World.thrusterLightLeft = this;	
		}else{
			World.thrusterLightRight = this;	
		}
		this.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(light.enabled){
			flickerProgress += 0.05f;
			light.intensity = 3.56f + Mathf.Sin(flickerProgress);
		}
	}
}
