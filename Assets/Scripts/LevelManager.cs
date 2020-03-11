using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		//Debug.Log("Level load requested for: "+ name);
		SceneManager.LoadScene(name);
	}
	
	public void QuitRequest(){
		//Debug.Log("Quit");
		Application.Quit();
	}

	public void LoadStartMenuScene()
	{
		Brick.setBreakableCount(0);
		FindObjectOfType<GameStatus>().AutoDestroy();
		SceneManager.LoadScene(0);
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
