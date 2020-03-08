using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	[SerializeField] float minX = 1f;
	[SerializeField] float maxX = 15f;
	[SerializeField] float screenWidthInUnits = 16f;

	private GameObject ball;
	private bool autoPlay = false;

	void Start(){
		ball = GameObject.FindGameObjectWithTag("Ball");
	}
			
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}	
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		transform.position = paddlePos;	
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f, transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,minX,maxX);
		transform.position = paddlePos;	
	}
	
	public void setAutoPlay(bool value)
	{
		autoPlay = value;
	}
}
