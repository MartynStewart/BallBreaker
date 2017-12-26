using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UICode : MonoBehaviour {

	public Text blockText;
	public Text PaddleText;
	private Time tStart;
	public Text uiMSG;
	public Text timeText;
	
	// Update is called once per frame
	void Update () {
		UpdateBCount();
		UpdatePTimer();
	}
	
	public void UpdateBCount(){
		if (Ball.ballCount>=2) {
			uiMSG.text="Multiball Active";
		} else uiMSG.text="";
		blockText.text = BrickScript.brickCount.ToString();
		timeText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
	}
	
	void UpdatePTimer(){
		int tLeft = Paddle.pChangeTime - Mathf.RoundToInt(Time.timeSinceLevelLoad);
		if (tLeft<=0) {
			PaddleText.text = "";
		}else PaddleText.text = "Big Paddle: "+tLeft.ToString();
	}
}
