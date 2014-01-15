using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableObject : MonoBehaviour {
	
	public static Dictionary<string, string[]> combos = new Dictionary<string, string[]>();
	public static Dictionary<string, string> comboDescriptions = new Dictionary<string, string>();
	public int possibleProblems = 0;
	public string[] problems;
	
	public string currentProblem = "";
	
	// Use this for initialization
	void Start () {
		currentProblem = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void interactWith(){
		Debug.Log("interactableobject");
	}
	
	//Checks if you can start solving the current issue
	public virtual string canStartSolving(){
		return "";
	}
}
