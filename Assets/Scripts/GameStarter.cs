using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {
	
	int tickDelay = 90;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tickDelay--;
		if(tickDelay == 0){
			World.setupPathMarkerConnections();
			World.assignRolesToMobs();
			World.assignClosestNodeToMobs();
			
			GameObject go = GameObject.Find ("MobCaptain");
			Mob m = (Mob)go.GetComponent("Mob");
			GameObject go2 = GameObject.Find ("PMBridgeCaptainDesk");
			PathMarker pm = (PathMarker)go2.GetComponent("PathMarker");
			
			Debug.Log ("Mob = "+m.name);
			Debug.Log ("Path = "+pm.name);
			
			m.moveTowards(pm);
			
			World.gameState = World.GAMESTATE_GAME;
			World.addProblem("OilPowerPlant", World.powerplant);
			World.addProblem("StartEngine", World.engine);
			
			Destroy (this.gameObject);
		}
	}
}
