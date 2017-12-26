using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	public static int brickCount = 0;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;
	
	private Ball ball;
	private int timesHit;	
	private LevelManager levelmanager;
	private bool isBreakable;
	private bool isMultiball;
	private bool isBarblock;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		isMultiball = (this.tag == "Multiball");
		isBarblock = (this.tag == "BarBlock");
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		if (isBreakable) brickCount++;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		
			if (isBreakable)	handleHits();
		else if (isMultiball) handleMB();
		else if (isBarblock) handleBB();
		
		}
		
	void handleHits(){
		int maxHits = hitSprites.Length+1;
		timesHit++;
		
		if(timesHit >= maxHits){
			brickCount--;
			GameObject SmokePuff = Instantiate(smoke,transform.position,Quaternion.identity) as GameObject;
			SmokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
			levelmanager.BrickDestroyed();
		} else {
			LoadSprites();
			brickC(maxHits-timesHit);
		}
		AudioSource.PlayClipAtPoint (crack, transform.position);
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit-1;
		if (hitSprites[spriteIndex]) this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	
	void brickC(int brickCount){
		if (brickCount==1) this.GetComponent<SpriteRenderer>().color = Color.yellow;
		else if(brickCount==2) this.GetComponent<SpriteRenderer>().color = Color.green;
	}
	
		//Used for MultiBall tagged bricks to generate 3 more balls in play
	void handleMB(){
		for (int i=0;i<=2;i++){
			ball = GameObject.FindObjectOfType<Ball>();
			Ball go = (Ball)Instantiate(ball,transform.position,Quaternion.identity);
			go.name = "Ball";
			go.hasStarted=true;
			Vector2 newLaunch = new Vector2 (Random.Range(-5f,5f),Random.Range(1f,5f));
			go.rigidbody2D.velocity = newLaunch;
		}
		handleHits();
	}
		//Used for BarBlock tagged bricks to extend the size of the paddle
	void handleBB(){
		if(Paddle.paddleSizeMod==1){		//Only runs if the bar is already above size if no then time just gets incremented
			Paddle paddle = GameObject.FindObjectOfType<Paddle>();
			Vector3 temp = paddle.transform.localScale;
			Paddle.paddleSizeMod = Paddle.pSizeDelta;
			temp.x = temp.x*Paddle.paddleSizeMod;
			paddle.transform.localScale = temp;
			paddle.GetComponent<SpriteRenderer>().color = Color.green;
		}
		Paddle.pChangeTime = Mathf.RoundToInt(Time.timeSinceLevelLoad)+Paddle.pChangeDelta;
		handleHits();
	}
}
