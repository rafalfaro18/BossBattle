using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float rotateSpeed = 100.0f;
	public GameObject magicOrb = null;
	public Transform socket = null;
	public int magicOrbAmount = 20;

	void Update(){
		Move ();
		Shoot ();
	}

	void Move(){
		float move = Input.GetAxis("Vertical") * moveSpeed; //Input form keyboard ws, mouse or joystick
		float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
		this.transform.Translate( 0,0, move * Time.deltaTime);
		this.transform.Rotate (0, rotation * Time.deltaTime, 0);
	}

	void Shoot(){
		if(Input.GetButtonDown("Fire1")){ //Project Settings -> Input: ctrl, mouse or joystick button
			if(magicOrbAmount > 0){
				magicOrbAmount--;	
				GameObject obj = Instantiate (magicOrb, socket.position, socket.rotation) as GameObject;
				obj.name = "magicOrgb";
			}
		}
	}
}
