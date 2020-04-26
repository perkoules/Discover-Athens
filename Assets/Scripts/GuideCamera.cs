using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideCamera : MonoBehaviour {

	public Camera playerCam;
	public GameObject[] terrains;
	private Camera guideCam;
	private Animator anim;
	GameObject objTemp;

	// Use this for initialization
	void Start () {
		playerCam = GetComponentInChildren<Camera>();
		guideCam = GetComponentInChildren<Camera>();
		anim = GetComponent<Animator>();
		foreach (GameObject obj in terrains){
			GameObject objTemp = Instantiate(obj,obj.transform.position, Quaternion.identity);
			objTemp.transform.SetParent(this.gameObject.transform);
		}
		StartDuration();
	}

	void Update()
	{
		if(anim.GetFloat("St") < 0){
			playerCam.enabled = true;
			Destroy(this.gameObject);
			Destroy(objTemp);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			if(anim.GetFloat("St")>0){
				playerCam.enabled = false;
				guideCam.enabled = true;
			}
		}
	}

	void StartDuration()
	{
		anim.SetFloat("St",1);
	}

	void StopDuration()
	{
		anim.SetFloat("St",-1);
	}


}
