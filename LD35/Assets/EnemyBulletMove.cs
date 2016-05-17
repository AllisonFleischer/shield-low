using UnityEngine;
using System.Collections;

public class EnemyBulletMove : MonoBehaviour {

	public float bulletSpeed;
	public GameObject player;
	public float decayTime = 10f;
	public Vector3 playerSkew;

	private Vector3 dir;

	// Use this for initialization
	void Start () {
		// Player targeting
		if (GameObject.Find ("Player")) {
			dir = ((GameObject.Find ("Player").transform.position + playerSkew) - transform.position).normalized;
		} else { // If player is dead, target random position
			dir = ((new Vector3 (Random.Range(-20f,20f), Random.Range(-20f,20f)) - transform.position).normalized);
		}
		GetComponent<Rigidbody2D>().AddForce (dir * bulletSpeed);
		transform.rotation = Quaternion.LookRotation (dir);
		transform.Rotate (new Vector3 (0f, -90f, 0f));
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
