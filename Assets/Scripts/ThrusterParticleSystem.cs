using UnityEngine;
using System.Collections;

public class ThrusterParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		World.thrusterParticleSystems.Add (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
