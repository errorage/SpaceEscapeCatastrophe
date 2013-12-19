using UnityEngine;
using System.Collections;

public class UI_Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.uiKeyTiles.Add(this.name, this);
		this.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
