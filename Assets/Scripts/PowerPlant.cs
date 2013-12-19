using UnityEngine;
using System.Collections;

public class PowerPlant : InteractableObject {
	
	
	public bool powerplantOn = false;
	
	// Use this for initialization
	void Start () {
		problems = new string[]{"OilPowerPlant"};
		possibleProblems = problems.Length;
		World.powerplant = this;
		InteractableObject.combos.Add("OilPowerPlant", new string[]{"s","a","a","w"});
		InteractableObject.comboDescriptions.Add("OilPowerPlant", "The power generator needs oil. \nOpen the hatch, squirt oil\n twice and close the hatch.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void interactWith(){
		Debug.Log ("powerplant");
		
		World.enableInteractionWindow(currentProblem);
	}
	
	public override string canStartSolving(){
		
		return "";
	}
}
