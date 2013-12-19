using UnityEngine;
using System.Collections;

public class Engine : InteractableObject {
	
	
	public bool engineOn = false;
	
	// Use this for initialization
	void Start () {
		problems = new string[]{"StartEngine", "FixEnginePipe", "EngineWiring", "EngineTransmission"};
		possibleProblems = problems.Length;
		World.engine = this;
		InteractableObject.combos.Add("StartEngine", new string[]{"s","w","s","w"});
		InteractableObject.comboDescriptions.Add("StartEngine", "Kickstart the engine by \npushing and pulling on \nthe pedal.");
		InteractableObject.combos.Add("FixEnginePipe", new string[]{"p"});
		InteractableObject.comboDescriptions.Add("FixEnginePipe", "An engine thruster pipe\n became undone. \nPlug it back");
		InteractableObject.combos.Add("EngineWiring", new string[]{"g","s","w","w","s","s"});
		InteractableObject.comboDescriptions.Add("EngineWiring", "Faulty enigne wiring. \nPut insulated gloves\n on and fix it with \na screwdrivers and \nwirecutters.");
		InteractableObject.combos.Add("EngineTransmission", new string[]{"h","h","h","h"});
		InteractableObject.comboDescriptions.Add("EngineTransmission", "There's a problem \nwith the engine's \ntransmission. Bash it \nwith a hammer!");
	}
	
	// Update is called once per frame
	void Update () {
		if(currentProblem != ""){
			engineOn = false;
		}else{
			engineOn = true;
		}
	}
	
	public override void interactWith(){
		Debug.Log ("engine");
		
		World.enableInteractionWindow(currentProblem);
	}
	
	public override string canStartSolving(){
		switch(currentProblem){
		case "StartEngine":
			if(World.powerplant.powerplantOn){
				return "";
			}else{
				return "Requires power. Start power plant.";
			}
			break;
		}
		return "";
	}
}
