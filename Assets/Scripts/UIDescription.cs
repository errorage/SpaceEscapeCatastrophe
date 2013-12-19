using UnityEngine;
using System.Collections;

public class UIDescription : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.uiDescription = this;
		World.uiDescription.guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
