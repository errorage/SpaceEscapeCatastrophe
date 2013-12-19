using UnityEngine;
using System.Collections;

public class UI_KeyText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.uiKeyTextTiles.Add(this.name, this);
		this.guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
