using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		//Debug.Log("Level load requested for: "+ name);
		Brick.setBreakableCount(0);
		SceneManager.LoadScene(name);
	}
	
	public void QuitRequest(){
		//Debug.Log("Quit");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		Brick.setBreakableCount(0);

		SceneManager.LoadScene(currentSceneIndex + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.getBreakableCount() <= 0){
			LoadNextLevel();
		}	
	}
}
