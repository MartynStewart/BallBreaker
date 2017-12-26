using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	public bool hasStarted = false;
	public static int ballCount = 0;
	
	// Use this for initialization
	void Start () {
		ballCount++;
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButton(0)){
				this.rigidbody2D.velocity = new Vector2(1.5f,10f);
				hasStarted = true;
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (hasStarted){
			Vector2 tweak = new Vector2 (Random.Range(-0.2f,0.2f),Random.Range(-0.2f,0.2f));
			rigidbody2D.velocity+=tweak;
			if (collision.collider.gameObject.name==paddle.name)audio.Play();
		}
	}
}