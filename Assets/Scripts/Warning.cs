using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {
	
	public bool inUse = false;
	public InteractableObject tiedToInteractableObject;
	
	// Use this for initialization
	void Start () {
		World.warningTiles.Add(this);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void useWith(InteractableObject io)
	{
		tiedToInteractableObject = io;
		inUse = true;
		transform.position = new Vector3(io.transform.position.x, 1.1f, io.transform.position.z);
	}
	
	void OnMouseDown(){
		Debug.Log ("ABC");
		if(tiedToInteractableObject != null){
			tiedToInteractableObject.interactWith();
		}
	}
}
