using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool AutoPlay = false;			//Testing autoplay feature
	private Ball ball;
	public static int paddleSizeMod = 1;	//Tracker for paddle size
	public static int pSizeDelta = 4;		//Paddle size multiplier
	public static int pChangeDelta = 10;	//How long the paddle remains changed
	public static int pChangeTime = 0;		//The time when the paddle will revert
	
	void Update(){	
		if (!AutoPlay) {
			MoveWithMouse();
		} else {
			Auto_Play();
		}
		ControlBigPaddle();
		Auto_PlayToggle();
	}
	
	void MoveWithMouse(){
		Vector3 PaddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float _xPos = Mathf.Clamp(Input.mousePosition.x/ Screen.width * 16,paddleSizeMod,16f-(paddleSizeMod));
		PaddlePos.x = _xPos;
		this.transform.position = PaddlePos;
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.gameObject.rigidbody2D.velocity.y<=5) collision.gameObject.rigidbody2D.velocity.y.Equals(collision.gameObject.rigidbody2D.velocity.y*5f);
	}
	
	void Auto_Play(){
		ball = GameObject.FindObjectOfType<Ball>();
		Vector3 PaddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		PaddlePos.x = ball.transform.position.x;
		this.transform.position = PaddlePos;
	}
	
	void ControlBigPaddle(){
		if(paddleSizeMod!=1){
			if(pChangeTime==Mathf.RoundToInt(Time.timeSinceLevelLoad)){
				Vector3 temp = this.transform.localScale;
				temp.x = temp.x/paddleSizeMod;
				this.transform.localScale = temp;
				paddleSizeMod=1;
				GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}
	void Auto_PlayToggle(){
		if (Input.GetKeyDown(KeyCode.F)) AutoPlay = !AutoPlay;
	}
}
