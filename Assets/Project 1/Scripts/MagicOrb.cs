using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour {
	// speed, hitpoint, shoot sound, hit sound, particle

	public int hitpoint = 10;
	public float speed = 5.0f;
	public AudioClip audioHit = null;
	public AudioClip audioShoot = null;
	public ParticleSystem particle = null;
}
