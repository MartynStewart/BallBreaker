using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	
	void Awake(){
		if (instance != null) {
			Destroy (gameObject);	
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(instance);
		} 
	}
	
	void Update(){		//Audiolocation changes with mouse x position
		GetComponent<AudioSource>().pan = Mathf.Clamp(Input.mousePosition.x/Screen.width*2-1,-1f,1f);
	}
}