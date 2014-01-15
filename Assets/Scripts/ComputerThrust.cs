using UnityEngine;
using System.Collections;

public class ComputerThrust : InteractableObject {
	
	public bool working = true;
	
	
	// Use this for initialization
	void Start () {
		currentProblem = "";
		problems = new string[]{"RestartThrust", "BSODThrust"};
		possibleProblems = problems.Length;
		World.computerThrust = this;
		InteractableObject.combos.Add("RestartThrust", new string[]{"c","a","d","p"});
		InteractableObject.comboDescriptions.Add("RestartThrust", "Computer needs a restart.\n Press c, a, d and \nthen restart.");
		InteractableObject.combos.Add("BSODThrust", new string[]{"p","p","p","p","p","p"});
		InteractableObject.comboDescriptions.Add("BSODThrust", "Computer encountered a\n bluescreen. Press the\n power button repeatedly.");
	}
	
	// Update is called once per frame
	void Update () {
		if(currentProblem != ""){
			working = false;
		}else{
			working = true;
		}
	}
	
	public override void interactWith(){
		Debug.Log ("ComputerThrust");
		World.enableInteractionWindow(currentProblem);
	}
	
	public override string canStartSolving(){
		switch(currentProblem){
		case "RestartThrust":
			if(World.powerplant.powerplantOn){
				return "";
			}else{
				return "Requires power. Start power plant.";
			}
			break;
		case "BSODThrust":
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
