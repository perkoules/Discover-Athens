using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

	
	public void LoadLevelByName(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		if (Application.platform == RuntimePlatform.WindowsPlayer){
			Application.Quit();
		}else if (Application.platform == RuntimePlatform.Android){
			Application.Quit();
		}else if (Application.platform == RuntimePlatform.IPhonePlayer){
			Application.Quit();
		}else if (Application.platform == RuntimePlatform.WebGLPlayer){
			Application.OpenURL("https://simmer.io/@Perkoules");
		}
		
	}
}
