using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		var x = Input.GetAxis("Horizontal") * Time.deltaTime ;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x*300.0f, 0);
		transform.Translate(x*3.0f, 0, 0);
		transform.Translate(0, 0, z);
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}

	}


	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
}
