using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World {
	
	public const int GAMESTATE_PREGAME = 10;
	public const int GAMESTATE_GAME = 20;
	public const int GAMESTATE_OVER = 30;
	
	public static List<PathMarker> pathMarkers = new List<PathMarker>();
	public static List<Mob> mobs = new List<Mob>();
	public static List<UI_MobButton> uiMobButtons = new List<UI_MobButton>();
	public static List<Warning> warningTiles = new List<Warning>();
	
	public static Mob selectedMob = null;
	public static int gameState = GAMESTATE_PREGAME;
	public static Dictionary<string, UI_Key> uiKeyTiles = new Dictionary<string, UI_Key>();
	public static Dictionary<string, UI_KeyText> uiKeyTextTiles = new Dictionary<string, UI_KeyText>();
	public static Dictionary<string, InteractableObject> problems = new Dictionary<string, InteractableObject>();
	public static Dictionary<string, Warning> problemWarning = new Dictionary<string, Warning>();
	
	public static ThrusterLight thrusterLightLeft;
	public static ThrusterLight thrusterLightRight;
	public static MainLight mainLightCaptain;
	public static MainLight mainLightLeft;
	public static MainLight mainLightRight;
	
	public static UI_Background interactionBackground;
	public static UI_ButtonClose closeButton;
	public static UIDescription uiDescription;
	public static UI_Score uiScore;
	public static UI_Score uiSpeed;
	public static UI_GameOver uiGameOver;
	
	public static Engine engine;
	public static PowerPlant powerplant;
	public static ComputerInternet computerInternet;
	public static ComputerNav computerNav;
	public static ComputerThrust computerThrust;
	public static O2Generator o2Generator;
	
	public static UIBar uiBarHealth;
	public static UIBar uiBarOxy;
	
	public static float ShipStateOxygen = 100;
	public static float playerHealth = 100;
	
	public static float shipSpeed = 0;
	
	
	
	public static PathMarker getPathMarkerByName(string name)
	{
		foreach(PathMarker pm in pathMarkers)
		{
			if(pm.nodeName == name){
				return pm;
			}
		}
		return null;
	}
	
	public static void setupPathMarkerConnections(){
		
		PathMarker pmBridge = getPathMarkerByName("Bridge");
		PathMarker pmNav = getPathMarkerByName("NavDesk");
		PathMarker pmOfficer = getPathMarkerByName("OfficerDesk");
		PathMarker pmCaptain = getPathMarkerByName("CaptainDesk");
		
		pmBridge.connectedNodes.Add(pmNav);
		pmBridge.connectedNodes.Add(pmOfficer);
		pmBridge.connectedNodes.Add(pmCaptain);
		
		pmNav.connectedNodes.Add(pmBridge);
		pmOfficer.connectedNodes.Add(pmBridge);
		pmCaptain.connectedNodes.Add(pmBridge);
		
		pmBridge.pathfinding.Add("Bridge", pmBridge);
		pmBridge.pathfinding.Add("NavDesk", pmNav);
		pmBridge.pathfinding.Add("CaptainDesk", pmCaptain);
		pmBridge.pathfinding.Add("OfficerDesk", pmOfficer);
		
		pmNav.pathfinding.Add("Bridge", pmBridge);
		pmNav.pathfinding.Add("NavDesk", pmNav);
		pmNav.pathfinding.Add("CaptainDesk", pmBridge);
		pmNav.pathfinding.Add("OfficerDesk", pmBridge);
		
		pmCaptain.pathfinding.Add("Bridge", pmBridge);
		pmCaptain.pathfinding.Add("NavDesk", pmBridge);
		pmCaptain.pathfinding.Add("CaptainDesk", pmCaptain);
		pmCaptain.pathfinding.Add("OfficerDesk", pmBridge);
		
		pmOfficer.pathfinding.Add("Bridge", pmBridge);
		pmOfficer.pathfinding.Add("NavDesk", pmBridge);
		pmOfficer.pathfinding.Add("CaptainDesk", pmBridge);
		pmOfficer.pathfinding.Add("OfficerDesk", pmOfficer);
		
		
	}
	
	public static void assignClosestNodeToMobs(){
		foreach(Mob m in mobs){
			PathMarker closestNode = null;
			float closestNodeDist = 9999999999;
			foreach(PathMarker pm in pathMarkers){
				float dx = m.transform.position.x - pm.transform.position.x;
				float dz = m.transform.position.z - pm.transform.position.z;
				
				float dist = dx*dx + dz*dz;
				
				if(dist < closestNodeDist)
				{
					closestNodeDist = dist;
					closestNode = pm;
				}
			}
			m.currentLocation = closestNode;
		}
	}
	
	public static void assignRolesToMobs()
	{
		int[] roles = new int[]{Mob.MOBTYPE_CAPTAIN, Mob.MOBTYPE_ENGINEER, Mob.MOBTYPE_SECURITY, Mob.MOBTYPE_MEDIC};
		int i = 0;
		foreach(Mob m in mobs){
			m.setMobType(roles[i]);
			i++;
			if(i == roles.Length){
				i = 0;	
			}
		}
		
	}
	
	public static Warning getIdleWarningSign(){
		foreach(Warning w in warningTiles)
		{
			if(!w.inUse)
			{
				return w;
			}
		}
		return null;
	}
	
	public static void enableInteractionWindow(string action){
		World.interactionBackground.guiTexture.enabled = true;
		World.closeButton.guiTexture.enabled = true;
		World.interactionBackground.active = true;
		World.interactionBackground.action = action;
		World.interactionBackground.step = 0;
		
		if(problems[action].canStartSolving() == ""){
			int i = 1;
			uiDescription.guiText.text = InteractableObject.comboDescriptions[action];
			uiDescription.guiText.enabled = true;
			foreach(string s in InteractableObject.combos[action]){
				World.uiKeyTiles["UIKey"+i].guiTexture.enabled = true;
				World.uiKeyTextTiles["UIKey"+i+"Text"].guiText.enabled = true;
				World.uiKeyTextTiles["UIKey"+i+"Text"].guiText.text = s;
				i++;
			}
		}else{
			uiDescription.guiText.text = problems[action].canStartSolving();
			uiDescription.guiText.enabled = true;
		}
	}
	
	public static void disableInteractionWindow(){
		World.interactionBackground.guiTexture.enabled = false;
		World.closeButton.guiTexture.enabled = false;
		World.interactionBackground.active = false;
		World.uiDescription.guiText.enabled = false;
		
		for(int i = 1; i <= 8; i++){
			World.uiKeyTiles["UIKey"+i].guiTexture.enabled = false;
			World.uiKeyTextTiles["UIKey"+i+"Text"].guiText.enabled = false;
			World.uiKeyTiles["UIKey"+i].guiTexture.color = new Color(0,0,0,1);
		}
	}
	
	public static void addProblem(string s, InteractableObject io){
		Debug.Log ("adding problem "+s);
		problems.Add (s, io);
		io.currentProblem = s;
		Warning w = World.getIdleWarningSign();
		w.useWith(io);
		problemWarning.Add (s, w);
	}
	
	public static void removeProblem(string s){
		problems[s].currentProblem = "";
		problemWarning[s].transform.position = new Vector3(-100,0,-100);
		problemWarning[s].tiedToInteractableObject = null;
		problemWarning[s].inUse = false;
		problems.Remove (s);
		problemWarning.Remove (s);
	}
	
	public static float getShipSpeed(){
		
		return shipSpeed;
	}
}
