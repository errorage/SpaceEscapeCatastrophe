using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	
	public const int MOBTYPE_UNSET = 0;
	public const int MOBTYPE_CAPTAIN = 1;
	public const int MOBTYPE_ENGINEER = 2;
	public const int MOBTYPE_MEDIC = 3;
	public const int MOBTYPE_SECURITY = 4;
	
	bool initialized = false;
	bool moving = false;			//Only moves when this is true.
	public PathMarker currentLocation;		//Node at which we currently are
	PathMarker movingTowards;		//End target
	PathMarker movingTowardsHop;	//Node to node movement
	public int mobType = MOBTYPE_UNSET;
	
	UI_MobButton associatedUIButton;
	
	float speed = 0.02f;
	
	// Use this for initialization
	void Start () {
		World.mobs.Add (this);
		if (name == "MobPlayer") 
		{
			World.playerMob = this;
		}
		if (name == "MobCaptain") 
		{
			World.captainMob = this;
		}
		//gameObject.animation.Play ("Walk");
	}
	
	// Update is called once per frame
	void Update () {
		if(!initialized){
			int id = World.mobs.IndexOf(this);
			Debug.Log("mob id = "+id);
			associatedUIButton = World.uiMobButtons[id];
			associatedUIButton.associatedMob = this;
			associatedUIButton.guiTexture.enabled = true;
			initialized = true;
		}
		if (moving) {
			//animation.Play("walking");
			Animator a = (Animator)this.GetComponent ("Animator");
			a.enabled = true;
			a.CrossFade ("walking", 1);
			//Debug.Log ("FND");

			Vector3 pos = Vector3.zero;
			float dx = movingTowardsHop.transform.position.x - transform.position.x;
			float dz = movingTowardsHop.transform.position.z - transform.position.z;

			float dxa = Mathf.Max (-speed, Mathf.Min (dx, speed));
			float dza = Mathf.Max (-speed, Mathf.Min (dz, speed));

			pos.x = transform.position.x + dxa;
			pos.z = transform.position.z + dza;

			pos.y = 0.45f;
			//Debug.Log("pos = "+pos.x+", "+pos.y+", "+pos.z+";");
			//Debug.Log("old = "+transform.position.x+", "+transform.position.y+", "+transform.position.z+";");
			transform.position = pos;
			//Debug.Log("new = "+transform.position.x+", "+transform.position.y+", "+transform.position.z+";");

			if (Mathf.Abs (dx) < speed && Mathf.Abs (dz) < speed) {
				currentLocation = movingTowardsHop;
				if (movingTowards == movingTowardsHop) {
					moving = false;
					Animator anim = (Animator)this.GetComponent ("Animator");
					anim.enabled = false;
				} else {
					movingTowardsHop = currentLocation.getPathMarkerInDirectionOf (movingTowards.nodeName);
				}
			}
			transform.LookAt (movingTowardsHop.transform.position);
			transform.rotation = new Quaternion (0, transform.rotation.y, 0, transform.rotation.w); //+90 becasue of wrong model orientation
			transform.Rotate (new Vector3 (0, 90, 0));
		} else {
			Animator a = (Animator)this.GetComponent ("Animator");
			//a.CrossFade("idle", 20);
			//Debug.Log ("BOOP");

		}
	}
	
	public void moveTowards(PathMarker target){
		moving = true;
		movingTowards = target;
		movingTowardsHop = currentLocation.getPathMarkerInDirectionOf(movingTowards.nodeName);
	}
	
	public void setMobType(int newMobType)
	{
		mobType = newMobType;
		switch(mobType){
		case MOBTYPE_CAPTAIN:
			Debug.Log ("captain");
			associatedUIButton.guiTexture.texture = (Texture2D)Resources.Load("MobCaptain", typeof(Texture2D));
			break;
		case MOBTYPE_ENGINEER:
			Debug.Log ("engineer");
			associatedUIButton.guiTexture.texture = (Texture2D)Resources.Load("MobEngineer", typeof(Texture2D));
			break;
		case MOBTYPE_MEDIC:
			Debug.Log ("medic");
			associatedUIButton.guiTexture.texture = (Texture2D)Resources.Load("MobMedic", typeof(Texture2D));
			break;
		case MOBTYPE_SECURITY:
			Debug.Log ("security");
			associatedUIButton.guiTexture.texture = (Texture2D)Resources.Load("MobSecurity", typeof(Texture2D));
			break;
		}
	}
	
	public static string mobtype2name(int mobType){
		switch(mobType){
		case MOBTYPE_CAPTAIN:
			return "Captain";
		case MOBTYPE_ENGINEER:
			return "Engineer";
		case MOBTYPE_MEDIC:
			return "Medic";
		case MOBTYPE_SECURITY:
			return "Security";
		}
		return "Unknown";
	}
	
	public void selectMob()
	{
		//renderer.material.color = Color.green;
		World.selectedMob = this;
		Debug.Log("Selected mob "+mobtype2name(this.mobType));
	}
	
	public void deselectMob()
	{
		//renderer.material.color = Color.blue;
		if(World.selectedMob == this){
			World.selectedMob = null;
		}
		Debug.Log("Deselected mob "+mobtype2name(this.mobType));
	}
	
	void OnMouseDown(){
		Debug.Log ("ABC");
	}
	
}
