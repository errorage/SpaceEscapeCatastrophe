using UnityEngine;
using System.Collections;

public class Door_level_1 : MonoBehaviour {

	int doorOpenRotation = 0;
	bool opening;

	// Use this for initialization
	void Start () {
		Level1.door = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			doorOpenRotation++;
			Debug.Log(Level1.hinge);
			this.transform.RotateAround(Level1.hinge.transform.position, new Vector3(0,1,0), -1);
			if(doorOpenRotation == 90){
				opening = false;
			}
		}

		if (Input.GetKeyDown ("e")) 
		{
			float distance = Vector3.Distance(transform.position, Level1.playerLevel1.transform.position);
			if(distance < 2){
				Debug.Log("PASS");
				opening = true;
			}else{
				Debug.Log("FAIL");
			}
		}
	}
}
