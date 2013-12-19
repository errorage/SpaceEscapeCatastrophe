using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	int guiAnimationStep = 0;
	float score = 0;
	
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
		
		
		if(World.engine.engineOn){
			World.shipSpeed += 0.01f;
		}else{
			World.shipSpeed -= 0.02f;
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
		score += World.shipSpeed;
		World.uiScore.guiText.text = "Score: "+score;
		World.uiSpeed.guiText.text = "Speed: "+World.shipSpeed;
		
		if( ((int)Random.Range (0, problemChance)) == 1 ){
			int machine = Random.Range (0, (int)6);
			problemChance -= 1;
			
			switch (machine){
			case 0:
				if(World.engine.currentProblem == ""){
					int problemNum = Random.Range(0, World.engine.possibleProblems);
					World.addProblem( World.engine.problems[problemNum], World.engine );
				}
				break;
			case 1:
				if(World.powerplant.currentProblem == ""){
					int problemNum = Random.Range(0, World.powerplant.possibleProblems);
					World.addProblem( World.powerplant.problems[problemNum], World.powerplant );
				}
				break;
			case 2:
				if(World.computerInternet.currentProblem == ""){
					int problemNum = Random.Range(0, World.computerInternet.possibleProblems);
					World.addProblem( World.computerInternet.problems[problemNum], World.computerInternet );
				}
				break;
			case 3:
				if(World.computerNav.currentProblem == ""){
					int problemNum = Random.Range(0, World.computerNav.possibleProblems);
					World.addProblem( World.computerNav.problems[problemNum], World.computerNav );
				}
				break;
			case 4:
				if(World.computerThrust.currentProblem == ""){
					int problemNum = Random.Range(0, World.computerThrust.possibleProblems);
					World.addProblem( World.computerThrust.problems[problemNum], World.computerThrust );
				}
				break;
			case 5:
				if(World.o2Generator.currentProblem == ""){
					int problemNum = Random.Range(0, World.o2Generator.possibleProblems);
					World.addProblem( World.o2Generator.problems[problemNum], World.o2Generator );
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
