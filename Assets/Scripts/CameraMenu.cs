using UnityEngine;
using System.Collections;

public class CameraMenu : MonoBehaviour {

	int animationProgress = 0;
	bool animate = true;
	float speed = -0.001f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (animate) {
			animationProgress++;
			this.transform.Translate (speed, 0f, 0f);
			if (animationProgress == 800) {
				animate = false;
			}
		}

	}
}
