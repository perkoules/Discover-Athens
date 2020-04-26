using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny00 : MonoBehaviour {

	
	public PlayerMovement pm ;
	public GameObject playerGameObject;
	private Animator anim, playerAnim;
	private AudioSource audioSource;
	private Camera cam, playerCam;
	private bool playing= true, met = false;
	Quaternion playerRot;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		cam = GetComponentInChildren<Camera>();
		playerCam = playerGameObject.GetComponentInChildren<Camera>();
		playerAnim = playerGameObject.GetComponentInChildren<Animator>();
		cam.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position,playerGameObject.transform.position) < 15 && met== false)
        {
            PlayerAndGrannyMet();
			met =  true;
        }

        if (audioSource.isPlaying == false && playing == false){
			cam.enabled = false;
			playerCam.enabled = true;
			Destroy(this.gameObject);
		}
		
	}

    private void PlayerAndGrannyMet()
    {
        cam.enabled = true;
        playerAnim.SetBool("Stop", true);
        StartCoroutine("SoundPlay");
        pm.moving = false;
        playing = false;
    }

    IEnumerator SoundPlay()
	{
		audioSource.Play();
		anim.SetBool("Sound", true);

		yield return new WaitForSeconds(audioSource.clip.length);
	
		playerAnim.SetBool("Stop",false);
	}

}
