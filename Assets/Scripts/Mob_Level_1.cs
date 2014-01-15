using UnityEngine;
using System.Collections;

public class Mob_Level_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Level1.playerLevel1 = this;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a")) {
			this.transform.Rotate (0, -4, 0);
		}
		if (Input.GetKey ("d")) {
			this.transform.Rotate (0, 4, 0);
		}
		
		if (Input.GetKey ("w")) {
			//Debug.Log ("BOOP");
			this.transform.Translate(Vector3.left * 0.05f);
		}
		if (Input.GetKey ("s")) {
			this.transform.Translate(Vector3.right * 0.05f);
		}

		if (Input.GetKeyDown ("w")) {
			Animator a = (Animator)this.GetComponent ("Animator");
			a.enabled = true;
			a.CrossFade ("walking", 1);
		}
		if (Input.GetKeyDown ("s")) {
			Animator a = (Animator)this.GetComponent ("Animator");
			a.enabled = true;
			a.CrossFade ("walking", 1);
		}
		/*
		if (Input.GetKeyUp ("w")) {
			Animator a = (Animator)this.GetComponent ("Animator");
			a.enabled = true;
			a.CrossFade ("idle", 1);
		}
		if (Input.GetKeyUp ("s")) {
			Animator a = (Animator)this.GetComponent ("Animator");
			a.enabled = true;
			a.CrossFade ("idle", 1);
		}*/
		
	}
}
