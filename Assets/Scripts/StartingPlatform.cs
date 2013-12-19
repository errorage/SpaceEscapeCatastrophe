using UnityEngine;
using System.Collections;

public class StartingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z > -100){
			if(World.gameState == World.GAMESTATE_GAME){
				if(World.getShipSpeed() > 0){
					Vector3 v = transform.position;
					v.z -= World.getShipSpeed();
					transform.position = v;
				}
			}
		}
	
	}
}
