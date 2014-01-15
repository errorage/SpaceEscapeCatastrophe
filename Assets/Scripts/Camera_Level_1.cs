using UnityEngine;
using System.Collections;

public class Camera_Level_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Level1.playerLevel1 != null) {
			this.transform.position = new Vector3( Level1.playerLevel1.transform.position.x -1, Level1.playerLevel1.transform.position.y + 2, Level1.playerLevel1.transform.position.z -1);
			this.transform.LookAt( Level1.playerLevel1.transform.position );
			Vector2 mouseXY = new Vector2 (Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2);

			Vector3 pos = Level1.playerLevel1.transform.position;
			pos.y += 2;

			this.transform.RotateAround ( pos, new Vector3(0,1,0), mouseXY.x );
		}

	}
}
