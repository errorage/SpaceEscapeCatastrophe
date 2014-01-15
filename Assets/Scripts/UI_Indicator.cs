using UnityEngine;
using System.Collections;

public class UI_Indicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		switch (name) {
		case "UI_HealthIndicator1":
			World.uiHealthIndicator1 = this;
			break;
		case "UI_HealthIndicator2":
			World.uiHealthIndicator2 = this;
			break;
		case "UI_HealthIndicator3":
			World.uiHealthIndicator3 = this;
			break;
		case "UI_CommsIndicator1":
			World.uiCommsIndicator1 = this;
			break;
		case "UI_CommsIndicator2":
			World.uiCommsIndicator2 = this;
			break;
		case "UI_CommsIndicator3":
			World.uiCommsIndicator3 = this;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
