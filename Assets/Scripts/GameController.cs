using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	int guiAnimationStep = 0;
	float distance = 0;
	
	int problemChance = 400;
	Random r = new Random();
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(World.gameState != World.GAMESTATE_GAME){
			return;
		}
		
		guiAnimationStep++;
		if(guiAnimationStep > 1000){
			guiAnimationStep = 0;
		}
		
		if(World.o2Generator.airSystemOnline){
			World.ShipStateOxygen += 0.5f;
			World.ShipStateOxygen = Mathf.Min (World.ShipStateOxygen, 100);
		}else{
			World.ShipStateOxygen -= 0.1f;
			World.ShipStateOxygen = Mathf.Max (World.ShipStateOxygen, 0);
		}
		
		
		if(World.ShipStateOxygen <= 0){
			World.playerHealth -= 0.05f;
		}

		//Start police pursuit, update police distance
		if(distance > 10000){
			if (!World.policeChasing) {
				World.policeChasing = true;
				World.uiNotice.displayMessage("The authorities are in pursuit!", 90);
			}
			if(World.shipSpeed < 20){
				World.policeDistance -= 0.003f * (20 - World.shipSpeed);
			}
		}
		
		if(World.policeDistance <= 0){
			World.gameState = World.GAMESTATE_OVER;
			World.uiGameOver.guiText.enabled = true;
			World.uiMainMenu.guiTexture.enabled = true;
		}

		if(World.playerHealth <= 1){
			World.uiBarHealth.guiTexture.color = Color.black;
			World.gameState = World.GAMESTATE_OVER;
			World.uiGameOver.guiText.enabled = true;
		}if(World.playerHealth <= 25){
			if(guiAnimationStep % 30 == 0){
				World.uiBarHealth.guiTexture.color = Color.red;
			}else if(guiAnimationStep % 30 == 15){
				World.uiBarHealth.guiTexture.color = Color.black;
			}
		}else if(World.playerHealth <= 50){
			if(guiAnimationStep % 100 == 0){
				World.uiBarHealth.guiTexture.color = Color.yellow;
			}else if(guiAnimationStep % 100 == 50){
				World.uiBarHealth.guiTexture.color = Color.black;
			}
		}else{
			World.uiBarHealth.guiTexture.color = new Color( 1 - (World.playerHealth / 100), (World.playerHealth / 100), 0);
		}
		
		
		if(World.ShipStateOxygen <= 1){
			World.uiBarOxy.guiTexture.color = Color.black;
		}if(World.ShipStateOxygen <= 25){
			if(guiAnimationStep % 30 == 0){
				World.uiBarOxy.guiTexture.color = Color.red;
			}else if(guiAnimationStep % 30 == 15){
				World.uiBarOxy.guiTexture.color = Color.black;
			}
		}else if(World.ShipStateOxygen <= 50){
			if(guiAnimationStep % 100 == 0){
				World.uiBarOxy.guiTexture.color = Color.yellow;
			}else if(guiAnimationStep % 100 == 50){
				World.uiBarOxy.guiTexture.color = Color.black;
			}
		}else{
			World.uiBarOxy.guiTexture.color = new Color( 1 - (World.ShipStateOxygen / 100), (World.ShipStateOxygen / 100), 0);
		}

		//Trigger solving problems
		if (Input.GetKeyDown ("1")) 
		{
			if(World.powerplant.currentProblem != "")
			{
				World.powerplant.interactWith();
				World.playerMob.moveTowards(World.getPathMarkerByName("PowerPlant"));
			}
		}
		if (Input.GetKeyDown ("2")) 
		{
			if(World.engine.currentProblem != "")
			{
				World.engine.interactWith();
				World.playerMob.moveTowards(World.getPathMarkerByName("Engine"));
			}
		}
		if (Input.GetKeyDown ("3")) 
		{
			if(World.o2Generator.currentProblem != "")
			{
				World.o2Generator.interactWith();
				World.playerMob.moveTowards(World.getPathMarkerByName("O2Gen"));
			}
		}
		if (Input.GetKeyDown ("4")) 
		{
			if(World.computerThrust.currentProblem != "")
			{
				World.computerThrust.interactWith();
				World.playerMob.moveTowards(World.getPathMarkerByName("ThrustComp"));
			}
		}
		if (Input.GetKeyDown ("5")) 
		{
			if(World.computerNav.currentProblem != "")
			{
				World.computerNav.interactWith();
				World.playerMob.moveTowards(World.getPathMarkerByName("NavComp"));
			}
		}
		if (Input.GetKeyDown ("6")) 
		{
			if(World.computerInternet.currentProblem != "")
			{
				World.computerInternet.interactWith();
				World.playerMob.moveTowards(World.getPathMarkerByName("NavComp"));
			}
		}

		//Menu
		if (Input.GetKeyDown ("q")) 
		{
			if(World.gameState != World.GAMESTATE_OVER)
			{
				World.uiMainMenu.guiTexture.enabled = !World.uiMainMenu.guiTexture.enabled;
			}
		}

		//Switch camera
		if (Input.GetKeyDown ("0")) 
		{
			if(World.activeCamera == World.playerCamera)
			{
				World.activeCamera = World.mainCamera;
				World.mainCamera.camera.depth = 3;
				World.playerCamera.camera.depth = 2;
			}else{
				World.activeCamera = World.playerCamera;
				World.playerCamera.camera.depth = 3;
				World.mainCamera.camera.depth = 2;
			}
		}
		
		//Captaion Pacifying
		if (Input.GetKeyDown ("7")) 
		{
			if(World.captainAnger > 0)
			{
				int choice = Random.Range(1,10);
				switch(choice){
				case 1:
					World.uiNotice.displayMessage("Okay, I'll be right there, captain!", 90);
					break;
				case 2:
					World.uiNotice.displayMessage("Moment, captain!", 90);
					break;
				case 3:
					World.uiNotice.displayMessage("Yes cap'n!", 90);
					break;
				case 4:
					World.uiNotice.displayMessage("Calm down, I'm on my way, captain!", 90);
					break;
				case 5:
					World.uiNotice.displayMessage("I'm on my way, captain!", 90);
					break;
				case 6:
					World.uiNotice.displayMessage("Gladly, captain!", 90);
					break;
				case 7:
					World.uiNotice.displayMessage("Of course, captain!", 90);
					break;
				case 8:
					World.uiNotice.displayMessage("In a moment, captain!", 90);
					break;
				case 9:
					World.uiNotice.displayMessage("Won't be a moment, captain!", 90);
					break;
				}
				
				World.captainAnger -= 20;
			}
		}
		
		//Use one comms boon
		if (Input.GetKeyDown ("8")) 
		{
			if(World.policeDistance < 100)
			{
				if(World.commsPacksUsed >= 3){
					World.uiNotice.displayMessage("The authorities will no \nlonger fall for this.", 90);
				}else{
					World.policeDistance += 25;
					World.uiNotice.displayMessage("You confused the authorities\nmaking them lose progress.", 90);
					World.policeDistance = Mathf.Min (World.policeDistance, 100);
					World.playerMob.moveTowards(World.getPathMarkerByName("Comms"));
					World.commsPacksUsed++;
					switch(World.commsPacksUsed){
					case 1:
						World.uiCommsIndicator3.guiTexture.enabled = false;
						break;
					case 2:
						World.uiCommsIndicator2.guiTexture.enabled = false;
						break;
					case 3:
						World.uiCommsIndicator1.guiTexture.enabled = false;
						break;
					}
				}
			}
		}

		//Use one health pack
		if (Input.GetKeyDown ("9")) 
		{
			if(World.playerHealth < 100)
			{
				if(World.healthPacksUsed >= 3){
					World.uiNotice.displayMessage("No more health packs available.", 90);
				}else{
					World.playerHealth += 25;
					World.playerHealth = Mathf.Min (World.playerHealth, 100);
					World.playerMob.moveTowards(World.getPathMarkerByName("Medicine"));
					World.healthPacksUsed++;
					switch(World.healthPacksUsed){
					case 1:
						World.uiHealthIndicator3.guiTexture.enabled = false;
						break;
					case 2:
						World.uiHealthIndicator2.guiTexture.enabled = false;
						break;
					case 3:
						World.uiHealthIndicator1.guiTexture.enabled = false;
						break;
					}
				}
			}
		}

		if (World.computerInternet.currentProblem != "") {
			World.captainAnger += 0.05f;
		} else {
			World.captainAnger -= 0.25f;
		}

		World.captainAnger = Mathf.Max ( Mathf.Min (World.captainAnger, 100) , 0 );

		if (World.captainAnger > 0) {
			World.speechBubble.renderer.enabled = true;
			float anger = 0.1f + (World.captainAnger * 0.02f);
			World.speechBubble.transform.localScale = new Vector3 (anger, anger, anger);
		} else {
			World.speechBubble.renderer.enabled = false;
		}
		
		//Debug.Log ("0000");
		//Enables UI Elements
		if (World.powerplant.currentProblem == "") {
			World.uiMachine1.guiTexture.enabled = false;
		} else {
			World.uiMachine1.guiTexture.enabled = true;
		}
		if (World.engine.currentProblem == "") {
			World.uiMachine2.guiTexture.enabled = false;
		} else {
			World.uiMachine2.guiTexture.enabled = true;
		}
		if (World.o2Generator.currentProblem == "") {
			World.uiMachine3.guiTexture.enabled = false;
		} else {
			World.uiMachine3.guiTexture.enabled = true;
		}
		if (World.computerThrust.currentProblem == "") {
			World.uiMachine4.guiTexture.enabled = false;
		} else {
			World.uiMachine4.guiTexture.enabled = true;
		}
		if (World.computerNav.currentProblem == "") {
			World.uiMachine5.guiTexture.enabled = false;
		} else {
			World.uiMachine5.guiTexture.enabled = true;
		}
		if (World.computerInternet.currentProblem == "") {
			World.uiMachine6.guiTexture.enabled = false;
		} else {
			World.uiMachine6.guiTexture.enabled = true;
		}
		
		float archiveShipSpeed = World.shipSpeed;

		if(World.engine.engineOn){
			World.shipSpeed += 0.01f;
			foreach(ThrusterParticleSystem tps in World.thrusterParticleSystems){
				tps.particleSystem.enableEmission = true;
			}
		}else{
			World.shipSpeed -= 0.02f;
			foreach(ThrusterParticleSystem tps in World.thrusterParticleSystems){
				tps.particleSystem.enableEmission = false;
			}
		}
		
		if(World.computerThrust.working){
			World.shipSpeed += 0.005f;
		}else{
			World.shipSpeed -= 0.01f;
		}
		
		if(World.computerNav.working){
			World.shipSpeed += 0.005f;
		}else{
			World.shipSpeed -= 0.01f;
		}
		
		World.shipSpeed = Mathf.Max (World.shipSpeed, 0);
		World.shipSpeed = Mathf.Min (World.shipSpeed, 30);

		if (World.shipSpeed > 0) 
		{
			if(archiveShipSpeed > World.shipSpeed){
				foreach(Box b in World.boxes){
					b.rigidbody.AddForce(0,0,10);
				}
			}else{
				foreach(Box b in World.boxes){
					b.rigidbody.AddForce(0,0,-10);
				}
			}
		}

		distance += World.shipSpeed;
		World.uiScore.guiText.text = "Distance: "+distance;
		World.uiSpeed.guiText.text = "Speed: "+World.shipSpeed;
		World.uiPoliceDistance.guiText.text = "Police distance: "+World.policeDistance;

		if (distance > 1000) {
			if (((int)Random.Range (0, problemChance)) == 1) {
				int machine = Random.Range (0, (int)6);
				problemChance -= 1;

				switch (machine) {
				case 0:
					if (World.engine.currentProblem == "") {
						int problemNum = Random.Range (0, World.engine.possibleProblems);
						World.addProblem (World.engine.problems [problemNum], World.engine);
					}
					break;
				case 1:
					if (World.powerplant.currentProblem == "") {
						int problemNum = Random.Range (0, World.powerplant.possibleProblems);
						World.addProblem (World.powerplant.problems [problemNum], World.powerplant);
					}
					break;
				case 2:
					if (World.computerInternet.currentProblem == "") {
						int problemNum = Random.Range (0, World.computerInternet.possibleProblems);
						World.addProblem (World.computerInternet.problems [problemNum], World.computerInternet);
					}
					break;
				case 3:
					if (World.computerNav.currentProblem == "") {
						int problemNum = Random.Range (0, World.computerNav.possibleProblems);
						World.addProblem (World.computerNav.problems [problemNum], World.computerNav);
					}
					break;
				case 4:
					if (World.computerThrust.currentProblem == "") {
						int problemNum = Random.Range (0, World.computerThrust.possibleProblems);
						World.addProblem (World.computerThrust.problems [problemNum], World.computerThrust);
					}
					break;
				case 5:
					if (World.o2Generator.currentProblem == "") {
						int problemNum = Random.Range (0, World.o2Generator.possibleProblems);
						World.addProblem (World.o2Generator.problems [problemNum], World.o2Generator);
					}
					break;
				}
		
						/*
		public static Engine engine;
		public static PowerPlant powerplant;
		public static ComputerInternet computerInternet;
		public static ComputerNav computerNav;
		public static ComputerThrust computerThrust;
		public static O2Generator o2Generator;
		*/
		
			}
		}
	}
}
