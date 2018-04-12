using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;	
	public static int breakableCount = 0;	
	public GameObject smoke;	
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	private float crackVolume = 0.05f;
			
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit=0;
	}
	
	void OnCollisionEnter2D(Collision2D collision){	
		AudioSource.PlayClipAtPoint(crack, transform.position, crackVolume);	
		if (isBreakable){
			HandleHits();
		}
	}	

	void HandleHits(){
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();			
			SmokeEffect();
			Destroy (gameObject);
		}else{
			LoadSprites();
		}	
	}
	
	void SmokeEffect(){
		GameObject smokeEffect = Instantiate(smoke,transform.position, Quaternion.identity) as GameObject;
		smokeEffect.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;	
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];	
		}else{
			Debug.LogWarning("Brick Sprite Missing");
		}	
	}
}
