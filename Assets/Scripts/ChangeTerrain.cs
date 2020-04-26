using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTerrain : MonoBehaviour {

	// Use this for initialization
	public GameObject[] terrainsToSpawn;
	private Vector3[] previousTerrainDeleter = new Vector3[] {new Vector3(-266.8f,1,-442.2f), //Syntagma-Kerameikos
	new Vector3(324,1,-624),//Kerameikos-Filoppapou
	new Vector3(0,1,-75),//Filopappou-Acropolis
	new Vector3(-588,1,-14)};//Acropolis-SyntagmaNew
	private Vector3[] terrainPositions = new Vector3[] {new Vector3(306.5f,0.01f,-1151.9f),//Kerameikos
	new Vector3(373,0,0),//Filopappou
	new Vector3(-413,0.01f,-94)};//Acropolis
	int counterTerrains = 0;
	public GameObject ter;

	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.transform.position.x != -588){
			Destroy(ter);
			ter = Instantiate(terrainsToSpawn[counterTerrains+1],terrainPositions[counterTerrains],Quaternion.identity);
			this.gameObject.transform.position = previousTerrainDeleter[counterTerrains+1];
			counterTerrains++;
		}else if (other.gameObject.tag == "Player" && this.gameObject.transform.position.x == -588){
			SceneManager.LoadScene("End");
		}
	}

	
}
