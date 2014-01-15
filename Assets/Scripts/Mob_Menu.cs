using UnityEngine;
using System.Collections;

public class Mob_Menu : MonoBehaviour {

	int animationProgress = 0;
	float speed = -0.005f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		animationProgress++;
		this.transform.Translate (speed,0f,0f);
		if (animationProgress == 600) {
			animationProgress = 0;
			transform.Rotate(0f,180f,0f);
			//speed = -speed;
		}
	}
}
