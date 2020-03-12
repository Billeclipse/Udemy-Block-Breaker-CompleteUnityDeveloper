using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	[SerializeField] public AudioClip[] ballSounds;

	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 10f;
	[SerializeField] float randomFactor = 0.2f;

	private GameObject paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindGameObjectWithTag("Paddle");
		paddleToBallVector = transform.position - paddle.transform.position;
		myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//Lock the ball relative to the paddle.
			transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for a mouse press to launch.
			if(Input.GetMouseButtonDown(0)){			
				GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
				hasStarted=true;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){	
		Vector2 tweak = new Vector2(
			Random.Range(-randomFactor, randomFactor),
			Random.Range(-randomFactor, randomFactor));
		
		if(hasStarted){
			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
			myAudioSource.PlayOneShot(clip);
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
