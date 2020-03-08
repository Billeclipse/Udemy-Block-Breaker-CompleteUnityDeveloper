using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 10f;

	private GameObject paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindGameObjectWithTag("Paddle");
		paddleToBallVector = transform.position - paddle.transform.position;		
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
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		
		if(hasStarted){
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
