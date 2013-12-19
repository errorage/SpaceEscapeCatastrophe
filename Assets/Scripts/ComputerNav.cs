using UnityEngine;
using System.Collections;

public class ComputerNav : InteractableObject {

	public bool working = true;
	
	// Use this for initialization
	void Start () {
		problems = new string[]{"RestartNav", "BSODNav"};
		possibleProblems = problems.Length;
		World.computerNav = this;
		InteractableObject.combos.Add("RestartNav", new string[]{"c","a","d","p"});
		InteractableObject.comboDescriptions.Add("RestartNav", "Computer needs a restart. \nPress c, a, d and then restart.");
		InteractableObject.combos.Add("BSODNav", new string[]{"p","p","p","p","p","p"});
		InteractableObject.comboDescriptions.Add("BSODNav", "Computer encountered a \nbluescreen. Press the power\n button repeatedly.");
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
		Debug.Log ("ComputerNav");
		World.enableInteractionWindow(currentProblem);
	}
	
	public override string canStartSolving(){
		switch(currentProblem){
		case "RestartNav":
			if(World.powerplant.powerplantOn){
				return "";
			}else{
				return "Requires power. Start power plant.";
			}
			break;
		case "BSODNav":
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
