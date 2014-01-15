using UnityEngine;
using System.Collections;

public class O2Generator : InteractableObject {

	
	public bool airSystemOnline = true;
	
	// Use this for initialization
	void Start () {
		currentProblem = "";
		problems = new string[]{"O2Malfunction", "PipeUnplugged"};
		possibleProblems = problems.Length;
		World.o2Generator = this;
		InteractableObject.combos.Add("O2Malfunction", new string[]{"o","h","h","h","c"});
		InteractableObject.comboDescriptions.Add("O2Malfunction", "O2 generator malfunciton. \nOpen the machine, hit it with \na hammer 3 times and \nclose it.");
		InteractableObject.combos.Add("PipeUnplugged", new string[]{"p"});
		InteractableObject.comboDescriptions.Add("PipeUnplugged", "A pipe came loose. Plug it back.");
	}
	
	// Update is called once per frame
	void Update () {
		if(currentProblem != ""){
			airSystemOnline = false;
		}else{
			airSystemOnline = true;
		}
	}
	
	public override void interactWith(){
		Debug.Log ("O2Generator");
		World.enableInteractionWindow(currentProblem);
	}
	
	public override string canStartSolving(){
		switch(currentProblem){
		case "O2Malfunction":
			if(World.powerplant.powerplantOn){
				return "";
			}else{
				return "Requires power. Start power plant.";
			}
		}
		return "";
	}
}
