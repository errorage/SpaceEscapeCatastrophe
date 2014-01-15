using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (name == "Main Camera") {
			World.mainCamera = this;
		} else {
			World.playerCamera = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
