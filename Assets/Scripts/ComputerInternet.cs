using UnityEngine;
using System.Collections;

public class ComputerInternet : InteractableObject {
	
	
	// Use this for initialization
	void Start () {
		currentProblem = "";
		problems = new string[]{"UnplugRouter"};
		possibleProblems = problems.Length;
		World.computerInternet = this;
		InteractableObject.combos.Add("UnplugRouter", new string[]{"u","p"});
		InteractableObject.comboDescriptions.Add("UnplugRouter", "Captain's internet is down! \nUnplug the router and \nplug it back!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void interactWith(){
		Debug.Log ("powerplant");
		
		World.enableInteractionWindow(currentProblem);
	}
	
	public override string canStartSolving(){
		switch(currentProblem){
		case "UnplugRouter":
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
