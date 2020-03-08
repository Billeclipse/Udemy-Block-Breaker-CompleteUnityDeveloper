﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
		
	[SerializeField] public AudioClip crack;
	[SerializeField] public Sprite[] hitSprites;	
	[SerializeField] public GameObject smoke;
	[SerializeField] public float crackVolume = 0.05f;

	private static int breakableCount = 0;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;	
			
	// Use this for initialization
	void Start () {
		isBreakable = CompareTag("Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit=0;
	}

	[System.Obsolete]
	void OnCollisionEnter2D(Collision2D collision){	
		if(crack != null)
		{
			AudioSource.PlayClipAtPoint(crack, transform.position, crackVolume);
		}

		if (isBreakable){
			HandleHits();
		}
	}

	[System.Obsolete]
	void HandleHits(){
		if (hitSprites != null)
		{
			int maxHits = hitSprites.Length + 1;
			timesHit++;
			if (timesHit >= maxHits)
			{
				breakableCount--;
				levelManager.BrickDestroyed();
				SmokeEffect();
				Destroy(gameObject);
			}
			else
			{
				LoadSprites();
			}
		}		
	}

	[System.Obsolete]
	void SmokeEffect(){
		if(smoke != null && isBreakable)
		{
			GameObject smokeEffect = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokeEffect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
		}		
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites != null && hitSprites[spriteIndex] != null){
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];	
		}else{
			Debug.LogWarning("Brick Sprite Missing");
		}	
	}

	public static int getBreakableCount()
	{
		return breakableCount;
	}

	public static void setBreakableCount(int count)
	{
		breakableCount = count;
	}
}
