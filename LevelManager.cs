using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static string LastLevel = "Start";
	
	void Start(){
		if(Application.loadedLevel>=1 && Application.loadedLevel<=3) Screen.showCursor=false;
		else Screen.showCursor=true;
	}

	private void setVarStart(){
		Ball.ballCount = 0;
		BrickScript.brickCount = 0;
		Paddle.paddleSizeMod =1;
		Paddle.pChangeTime=0;
	}

	public void LoadLevel(string name){
		Application.LoadLevel(name);
		setVarStart();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
		setVarStart();
	}
	
	public void LoadLastLevel(){
		Application.LoadLevel(LastLevel);
		setVarStart();
	}
	
	public void QuitLevel(){
		Application.Quit();
	}
	
	public void BrickDestroyed(){
		if (BrickScript.brickCount<=0) LoadNextLevel();	
	}
}
