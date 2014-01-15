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
	
	public static Mob playerMob;
	public static Mob captainMob;
	public static PlayerHead playerHead;
	public static PlayerCamera playerCamera;
	public static PlayerCamera activeCamera;
	public static PlayerCamera mainCamera;
	
	public static UI_Background interactionBackground;
	public static UI_ButtonClose closeButton;
	public static UIDescription uiDescription;
	public static UI_Score uiScore;
	public static UI_Score uiSpeed;
	public static UI_Score uiPoliceDistance;
	public static UI_GameOver uiGameOver;
	public static UI_MainMenu uiMainMenu;
	
	public static Engine engine;
	public static PowerPlant powerplant;
	public static ComputerInternet computerInternet;
	public static ComputerNav computerNav;
	public static ComputerThrust computerThrust;
	public static O2Generator o2Generator;
	public static List<Box> boxes = new List<Box>();
	public static List<ThrusterParticleSystem> thrusterParticleSystems = new List<ThrusterParticleSystem>();
	
	public static UIBar uiBarHealth;
	public static UIBar uiBarOxy;
	public static UI_Notice uiNotice;
	public static UI_Machine uiMachine1;
	public static UI_Machine uiMachine2;
	public static UI_Machine uiMachine3;
	public static UI_Machine uiMachine4;
	public static UI_Machine uiMachine5;
	public static UI_Machine uiMachine6;
	public static UI_Indicator uiHealthIndicator1;
	public static UI_Indicator uiHealthIndicator2;
	public static UI_Indicator uiHealthIndicator3;
	public static UI_Indicator uiCommsIndicator1;
	public static UI_Indicator uiCommsIndicator2;
	public static UI_Indicator uiCommsIndicator3;
	
	public static float ShipStateOxygen = 100;
	public static float playerHealth = 100;
	public static int healthPacksUsed = 0;
	public static bool policeChasing = false;
	public static float policeDistance = 100;
	public static int commsPacksUsed = 0;

	public static SpeechBubble speechBubble;
	public static float captainAnger = 0;
	
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
		PathMarker pmBitcoinGen = getPathMarkerByName("BitcoinGen");
		PathMarker pmCaptainDesk = getPathMarkerByName("CaptainDesk");
		PathMarker pmComms = getPathMarkerByName("Comms");
		PathMarker pmEngine = getPathMarkerByName("Engine");
		PathMarker pmMedicine = getPathMarkerByName("Medicine");
		PathMarker pmNavComp = getPathMarkerByName("NavComp");
		PathMarker pmO2Gen = getPathMarkerByName("O2Gen");
		PathMarker pmPowerPlant = getPathMarkerByName("PowerPlant");
		PathMarker pmThrustComp = getPathMarkerByName("ThrustComp");
		
		pmBridge.connectedNodes.Add(pmBitcoinGen);
		pmBridge.connectedNodes.Add(pmCaptainDesk);
		pmBridge.connectedNodes.Add(pmComms);
		pmBridge.connectedNodes.Add(pmEngine);
		pmBridge.connectedNodes.Add(pmMedicine);
		pmBridge.connectedNodes.Add(pmNavComp);
		pmBridge.connectedNodes.Add(pmO2Gen);
		pmBridge.connectedNodes.Add(pmPowerPlant);
		pmBridge.connectedNodes.Add(pmThrustComp);
		
		pmBitcoinGen.connectedNodes.Add(pmBridge);
		pmBitcoinGen.connectedNodes.Add(pmO2Gen);
		pmBitcoinGen.connectedNodes.Add(pmMedicine);
		pmBitcoinGen.connectedNodes.Add(pmNavComp);
		
		pmCaptainDesk.connectedNodes.Add(pmBridge);
		
		pmComms.connectedNodes.Add(pmBridge);
		pmComms.connectedNodes.Add(pmThrustComp);
		pmComms.connectedNodes.Add(pmPowerPlant);
		
		pmEngine.connectedNodes.Add(pmBridge);
		pmEngine.connectedNodes.Add(pmThrustComp);
		pmEngine.connectedNodes.Add(pmNavComp);
		pmEngine.connectedNodes.Add(pmPowerPlant);
		pmEngine.connectedNodes.Add(pmO2Gen);
		
		pmMedicine.connectedNodes.Add(pmBridge);
		pmMedicine.connectedNodes.Add(pmO2Gen);
		pmMedicine.connectedNodes.Add(pmNavComp);
		
		pmNavComp.connectedNodes.Add(pmBridge);
		pmNavComp.connectedNodes.Add(pmO2Gen);
		pmNavComp.connectedNodes.Add(pmMedicine);
		pmNavComp.connectedNodes.Add(pmEngine);
		
		pmO2Gen.connectedNodes.Add(pmBridge);
		pmO2Gen.connectedNodes.Add(pmBitcoinGen);
		pmO2Gen.connectedNodes.Add(pmMedicine);
		pmO2Gen.connectedNodes.Add(pmEngine);
		pmO2Gen.connectedNodes.Add(pmNavComp);
		
		pmPowerPlant.connectedNodes.Add(pmBridge);
		pmPowerPlant.connectedNodes.Add(pmThrustComp);
		pmPowerPlant.connectedNodes.Add(pmComms);
		pmPowerPlant.connectedNodes.Add(pmEngine);
		
		pmThrustComp.connectedNodes.Add(pmBridge);
		pmThrustComp.connectedNodes.Add(pmPowerPlant);
		pmThrustComp.connectedNodes.Add(pmEngine);
		pmThrustComp.connectedNodes.Add(pmComms);
		
		pmBridge.pathfinding.Add("Bridge", pmBridge);
		pmBridge.pathfinding.Add("BitcoinGen", pmBitcoinGen);
		pmBridge.pathfinding.Add("CaptainDesk", pmCaptainDesk);
		pmBridge.pathfinding.Add("Comms", pmComms);
		pmBridge.pathfinding.Add("Engine", pmEngine);
		pmBridge.pathfinding.Add("Medicine", pmMedicine);
		pmBridge.pathfinding.Add("NavComp", pmNavComp);
		pmBridge.pathfinding.Add("O2Gen", pmO2Gen);
		pmBridge.pathfinding.Add("PowerPlant", pmPowerPlant);
		pmBridge.pathfinding.Add("ThrustComp", pmThrustComp);
		
		pmBitcoinGen.pathfinding.Add("Bridge", pmBridge);
		pmBitcoinGen.pathfinding.Add("BitcoinGen", pmBitcoinGen);
		pmBitcoinGen.pathfinding.Add("CaptainDesk", pmBridge);
		pmBitcoinGen.pathfinding.Add("Comms", pmBridge);
		pmBitcoinGen.pathfinding.Add("Engine", pmBridge);
		pmBitcoinGen.pathfinding.Add("Medicine", pmMedicine);
		pmBitcoinGen.pathfinding.Add("NavComp", pmNavComp);
		pmBitcoinGen.pathfinding.Add("O2Gen", pmO2Gen);
		pmBitcoinGen.pathfinding.Add("PowerPlant", pmBridge);
		pmBitcoinGen.pathfinding.Add("ThrustComp", pmBridge);
		
		pmCaptainDesk.pathfinding.Add("Bridge", pmBridge);
		pmCaptainDesk.pathfinding.Add("BitcoinGen", pmBridge);
		pmCaptainDesk.pathfinding.Add("CaptainDesk", pmCaptainDesk);
		pmCaptainDesk.pathfinding.Add("Comms", pmBridge);
		pmCaptainDesk.pathfinding.Add("Engine", pmBridge);
		pmCaptainDesk.pathfinding.Add("Medicine", pmBridge);
		pmCaptainDesk.pathfinding.Add("NavComp", pmBridge);
		pmCaptainDesk.pathfinding.Add("O2Gen", pmBridge);
		pmCaptainDesk.pathfinding.Add("PowerPlant", pmBridge);
		pmCaptainDesk.pathfinding.Add("ThrustComp", pmBridge);
		
		pmComms.pathfinding.Add("Bridge", pmBridge);
		pmComms.pathfinding.Add("BitcoinGen", pmBridge);
		pmComms.pathfinding.Add("CaptainDesk", pmBridge);
		pmComms.pathfinding.Add("Comms", pmComms);
		pmComms.pathfinding.Add("Engine", pmBridge);
		pmComms.pathfinding.Add("Medicine", pmBridge);
		pmComms.pathfinding.Add("NavComp", pmBridge);
		pmComms.pathfinding.Add("O2Gen", pmBridge);
		pmComms.pathfinding.Add("PowerPlant", pmPowerPlant);
		pmComms.pathfinding.Add("ThrustComp", pmThrustComp);
		
		pmEngine.pathfinding.Add("Bridge", pmBridge);
		pmEngine.pathfinding.Add("BitcoinGen", pmBridge);
		pmEngine.pathfinding.Add("CaptainDesk", pmBridge);
		pmEngine.pathfinding.Add("Comms", pmBridge);
		pmEngine.pathfinding.Add("Engine", pmEngine);
		pmEngine.pathfinding.Add("Medicine", pmBridge);
		pmEngine.pathfinding.Add("NavComp", pmNavComp);
		pmEngine.pathfinding.Add("O2Gen", pmO2Gen);
		pmEngine.pathfinding.Add("PowerPlant", pmPowerPlant);
		pmEngine.pathfinding.Add("ThrustComp", pmThrustComp);
		
		pmMedicine.pathfinding.Add("Bridge", pmBridge);
		pmMedicine.pathfinding.Add("BitcoinGen", pmO2Gen);
		pmMedicine.pathfinding.Add("CaptainDesk", pmBridge);
		pmMedicine.pathfinding.Add("Comms", pmBridge);
		pmMedicine.pathfinding.Add("Engine", pmBridge);
		pmMedicine.pathfinding.Add("Medicine", pmMedicine);
		pmMedicine.pathfinding.Add("NavComp", pmNavComp);
		pmMedicine.pathfinding.Add("O2Gen", pmO2Gen);
		pmMedicine.pathfinding.Add("PowerPlant", pmBridge);
		pmMedicine.pathfinding.Add("ThrustComp", pmBridge);
		
		pmNavComp.pathfinding.Add("Bridge", pmBridge);
		pmNavComp.pathfinding.Add("BitcoinGen", pmBridge);
		pmNavComp.pathfinding.Add("CaptainDesk", pmBridge);
		pmNavComp.pathfinding.Add("Comms", pmBridge);
		pmNavComp.pathfinding.Add("Engine", pmEngine);
		pmNavComp.pathfinding.Add("Medicine", pmMedicine);
		pmNavComp.pathfinding.Add("NavComp", pmNavComp);
		pmNavComp.pathfinding.Add("O2Gen", pmO2Gen);
		pmNavComp.pathfinding.Add("PowerPlant", pmBridge);
		pmNavComp.pathfinding.Add("ThrustComp", pmBridge);
		
		pmO2Gen.pathfinding.Add("Bridge", pmBridge);
		pmO2Gen.pathfinding.Add("BitcoinGen", pmBitcoinGen);
		pmO2Gen.pathfinding.Add("CaptainDesk", pmBridge);
		pmO2Gen.pathfinding.Add("Comms", pmBridge);
		pmO2Gen.pathfinding.Add("Engine", pmEngine);
		pmO2Gen.pathfinding.Add("Medicine", pmMedicine);
		pmO2Gen.pathfinding.Add("NavComp", pmNavComp);
		pmO2Gen.pathfinding.Add("O2Gen", pmO2Gen);
		pmO2Gen.pathfinding.Add("PowerPlant", pmBridge);
		pmO2Gen.pathfinding.Add("ThrustComp", pmBridge);
		
		pmPowerPlant.pathfinding.Add("Bridge", pmBridge);
		pmPowerPlant.pathfinding.Add("BitcoinGen", pmBridge);
		pmPowerPlant.pathfinding.Add("CaptainDesk", pmBridge);
		pmPowerPlant.pathfinding.Add("Comms", pmComms);
		pmPowerPlant.pathfinding.Add("Engine", pmEngine);
		pmPowerPlant.pathfinding.Add("Medicine", pmBridge);
		pmPowerPlant.pathfinding.Add("NavComp", pmBridge);
		pmPowerPlant.pathfinding.Add("O2Gen", pmBridge);
		pmPowerPlant.pathfinding.Add("PowerPlant", pmPowerPlant);
		pmPowerPlant.pathfinding.Add("ThrustComp", pmThrustComp);
		
		pmThrustComp.pathfinding.Add("Bridge", pmBridge);
		pmThrustComp.pathfinding.Add("BitcoinGen", pmBridge);
		pmThrustComp.pathfinding.Add("CaptainDesk", pmBridge);
		pmThrustComp.pathfinding.Add("Comms", pmComms);
		pmThrustComp.pathfinding.Add("Engine", pmEngine);
		pmThrustComp.pathfinding.Add("Medicine", pmBridge);
		pmThrustComp.pathfinding.Add("NavComp", pmBridge);
		pmThrustComp.pathfinding.Add("O2Gen", pmBridge);
		pmThrustComp.pathfinding.Add("PowerPlant", pmPowerPlant);
		pmThrustComp.pathfinding.Add("ThrustComp", pmThrustComp);
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

		if (action == "" || action == null) 
		{
			return;
		}

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
		problemWarning[s].tiedToInteractableObject.currentProblem = "";
		problemWarning[s].tiedToInteractableObject = null;
		problemWarning[s].inUse = false;
		problems.Remove (s);
		problemWarning.Remove (s);
	}
	
	public static float getShipSpeed(){
		
		return shipSpeed;
	}
}
