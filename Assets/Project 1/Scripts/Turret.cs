using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public GameObject canonball = null;
	public Transform player = null;
	public float minDelay = 1.0f;
	public float maxDelay = 4.0f;

	private float lasTime = 0.0f;
	private float delayTime = 0.0f;
	public int health = 100;
	public Color hitColor = Color.white;
	private Color originalColor = Color.white;

	void Awake(){
		originalColor = this.GetComponent<Renderer> ().material.color;
	}

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
			GameObject obj = Instantiate (canonball, this.transform.position, this.transform.rotation) as GameObject;
			obj.name = "canonball";
		}
	}

	float GetRandomValue(){
		return Random.Range (minDelay, maxDelay);
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "magicOrb") {
			int hp = other.GetComponent<MagicOrb> ().hitpoint;
			GetHealth (hp);
		}
	}

	void GetHealth(int hp){
		if (health > 0) {
			health -= hp;
			StartCoroutine (GetHit());

		} else {
			Destroy(this.gameObject);
		}
	}

	IEnumerator GetHit(){
		this.GetComponent<Renderer> ().material.color = hitColor;
		yield return new WaitForSeconds (0.4f);
		this.GetComponent<Renderer> ().material.color = originalColor;
	}
}
