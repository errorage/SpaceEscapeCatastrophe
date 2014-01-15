using UnityEngine;
using System.Collections;

public class UI_Machine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		switch (name) {
		case "UIMachine1":
			World.uiMachine1 = this;
			break;
		case "UIMachine2":
			World.uiMachine2 = this;
			break;
		case "UIMachine3":
			World.uiMachine3 = this;
			break;
		case "UIMachine4":
			World.uiMachine4 = this;
			break;
		case "UIMachine5":
			World.uiMachine5 = this;
			break;
		case "UIMachine6":
			World.uiMachine6 = this;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
