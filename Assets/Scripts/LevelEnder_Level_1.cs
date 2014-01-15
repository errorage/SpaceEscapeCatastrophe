using UnityEngine;
using System.Collections;

public class LevelEnder_Level_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(transform.position, Level1.playerLevel1.transform.position);
		if(distance < 1){
			Debug.Log("Level1 complete");
			Application.LoadLevel (2);
		}
	}
}
