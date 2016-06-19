using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public float bulletSpeed;
	public float decayTime = 10f;
	public Vector3 playerSkew;

	// Use this for initialization
	void Start () {
		// Mouse targeting
		Vector3 sp = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = (Input.mousePosition - sp).normalized;
		GetComponent<Rigidbody2D>().AddForce (dir * bulletSpeed);
		StartCoroutine(Decay());
	}

	IEnumerator Decay ()
	{
		yield return new WaitForSeconds (decayTime);
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
