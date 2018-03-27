using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public GameObject canonBall = null;
	public Transform player = null;
	public float minDelay = 1.0f;
	public float maxDelay = 4.0f;

	private float lasTime = 0.0f;
	private float delayTime = 0.0f;

	void Update(){
		FollowPLayer ();
		Shoot ();
	}

	void FollowPLayer(){
		this.transform.LookAt (player);
	}

	void Shoot(){
		if(Time.time > lasTime + delayTime){
			lasTime = Time.time;
			delayTime = GetRandomValue ();
			GameObject obj = Instantiate (canonBall, this.transform.position, this.transform.rotation) as GameObject;
			obj.name = "canonball";
		}
	}

	float GetRandomValue(){
		return Random.Range (minDelay, maxDelay);
	}
}
