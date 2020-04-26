using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionPlay : MonoBehaviour {

	public int questionSceneCounter = 0;
	private Vector3[] positions = new Vector3[] {new Vector3(-1068,0.02f,-36),//Zappeio
	new Vector3 (-1075,0.02f,-670),//Syntagma
	new Vector3(45,0.02f,-742), //Hephaestus
	new Vector3(115,0.02f,-80), //Filopappou
	new Vector3(-200,0.02f,-58),//Acropolis
	new Vector3(-1100,0.02f,0)};//End

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
			this.gameObject.transform.position = positions[questionSceneCounter];
			questionSceneCounter++;
			PlayerPrefs.SetInt("SceneNumber", questionSceneCounter);
			SceneManager.LoadScene(questionSceneCounter, LoadSceneMode.Additive);
		}
	}

}
