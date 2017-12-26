using UnityEngine;
using System.Collections;

public class LoseScript : MonoBehaviour {
	private LevelManager levelmanager;
	
	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (Ball.ballCount == 1){
			LevelManager.LastLevel=Application.loadedLevelName;
			levelmanager.LoadLevel("Lose");	
		}	else {
			Destroy(collision.gameObject);
			Ball.ballCount--;	
		}
	}
}
