using UnityEngine;
using System.Collections;

public class UI_Background : MonoBehaviour {
	
	public bool active = false;
	public string action = "";
	public int step = 0;

	// Use this for initialization
	void Start () {
		World.interactionBackground = this;
		this.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			string nextKey = InteractableObject.combos[action][step];
			World.uiKeyTiles["UIKey"+(step+1)].guiTexture.color = Color.yellow;
			//World.uiKeyTextTiles["UIKey"+(step+1)+"Text"].guiText.renderer.material.color = Color.red;
			if (Input.GetKeyDown(nextKey)){
				World.uiKeyTiles["UIKey"+(step+1)].guiTexture.enabled = false;
				World.uiKeyTextTiles["UIKey"+(step+1)+"Text"].guiText.enabled = false;
				step++;
			}
            if(step == InteractableObject.combos[action].Length){
				activeCleared ();
			}
		}
	}
	
	public void activeCleared(){
		
		switch(action){
		case "StartEngine":
		case "FixEnginePipe":
		case "EngineWiring":
		case "EngineTransmission":
			World.engine.engineOn = true;
			World.thrusterLightLeft.light.enabled = true;
			World.thrusterLightRight.light.enabled = true;
			break;
		case "OilPowerPlant":
			World.powerplant.powerplantOn = true;
			World.mainLightCaptain.light.intensity = 1;
			World.mainLightLeft.turnOnProcess();
			World.mainLightRight.turnOnProcess();
			break;
		case "O2Malfunction":
			World.o2Generator.airSystemOnline = true;
			break;
		case "RestartNav":
		case "BSODNav":
			World.computerNav.working = true;
			break;
		case "RestartThrust":
		case "BSODThrust":
			World.computerThrust.working = true;
			break;
		}
		World.problems[action].currentProblem = "";
		World.removeProblem(action);
		World.disableInteractionWindow();
	}
}
