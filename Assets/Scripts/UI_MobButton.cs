using UnityEngine;
using System.Collections;

public class UI_MobButton : MonoBehaviour {
	
	public Mob associatedMob;
	bool initialized = false;
	public int index = 0;
	
	// Use this for initialization
	void Start () {
		World.uiMobButtons.Add(this);
		this.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		if(associatedMob != null){
			if(World.selectedMob != null){
				World.selectedMob.deselectMob();
			}
			associatedMob.selectMob();
		}
	}
}
