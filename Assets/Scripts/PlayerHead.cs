using UnityEngine;
using System.Collections;

public class PlayerHead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.playerHead = this;
	}
	
	// Update is called once per frame
	void Update () {
		World.playerCamera.transform.position = this.transform.position;
		World.playerCamera.transform.Translate (0f,0.5f,0f);
		World.playerCamera.transform.rotation = this.transform.rotation;
		World.playerCamera.transform.Rotate (0f, -90f, 0f);
	}
}
