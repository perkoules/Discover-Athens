using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	Vector3 targetPosition, lookAtTarget;
	Quaternion playerRot;
	float rotSpeed = 5, speed = 20;
	public bool moving = false;
	private Animator anim;
	private Camera cam;
	public GameObject[] monuments;
	private Material matPath;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool("Stop",true);
		cam = GetComponentInChildren<Camera>();
		cam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerPrefs.GetString("AllCorrect") == "YES"){
			GetMonument();
		}

		if (SceneManager.sceneCount == 1){
			if (Input.GetMouseButton(0)){
				anim.SetBool("Stop", false);
				anim.Play("Walking");
				SetTargetPosition();
			}
		}

		if (moving){
			Move();
		}else{
			anim.SetBool("Stop",true);
		}
	}

	void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1000)){
			if(hit.transform.tag == "Road" || hit.transform.tag == "PointToPlay" || hit.transform.tag == "Deleter"){
				targetPosition = hit.point;
				lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
				transform.position.y,
				targetPosition.z - transform.position.z);
				playerRot = Quaternion.LookRotation(lookAtTarget);
				moving = true;
			}else{
				moving = false;
			}
			
		}

	}

	void Move()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation, playerRot,rotSpeed*Time.deltaTime);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition,speed*Time.deltaTime);

		if(transform.position == targetPosition){
			anim.SetBool("Stop",true);
			moving =false;
		}
	}

	void GetMonument()
	{
		Destroy(monuments[PlayerPrefs.GetInt("SceneNumber")-1]);
		PlayerPrefs.SetString("AllCorrect" , "NO");
	}

	
	 
}
