using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public float bulletSpeed;
	public Vector3 playerSkew;

	// Use this for initialization
	void OnEnable () {
		// Mouse targeting
		Vector3 sp = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = (Input.mousePosition - sp).normalized;
		GetComponent<Rigidbody2D>().AddForce (dir * bulletSpeed);
	}
		
	void OnBecameInvisible () {
		//Destroy (this.gameObject);
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
