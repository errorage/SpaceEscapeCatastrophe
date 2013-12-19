using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathMarker : MonoBehaviour {
	
	public List<PathMarker> connectedNodes = new List<PathMarker>();
	public string nodeName = "";
	public Dictionary<string, PathMarker> pathfinding = new Dictionary<string, PathMarker>();
	
	// Use this for initialization
	void Start () {
		World.pathMarkers.Add (this);
		this.renderer.enabled = false;
		//Debug.Log ("Makerlist contains "+World.pathMarkers.Count+" elements");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public PathMarker getPathMarkerInDirectionOf( string target ){
		return pathfinding[target];
	}
}
