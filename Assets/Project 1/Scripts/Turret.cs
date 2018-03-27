using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public GameObject canonBall = null;
	public Transform player = null;

	void Update(){
		FollowPLayer ();
	}

	void FollowPLayer(){
		this.transform.LookAt (player);
	}
}
