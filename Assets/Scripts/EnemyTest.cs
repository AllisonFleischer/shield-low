using UnityEngine;
using System.Collections;

public class EnemyTest : MonoBehaviour {

	public GameObject enemyBullet;
	public GameObject explosion;
	public GameObject hitExplosion;
	public int enemyStartHealth;
	public Vector3 movement;
	public float Life;
	public float shootLow;
	public float shootHigh;
	public float sleepTime;
	public bool invincible;

	private int enemyHealth;
	private bool Awake = true;

	// Use this for initialization
	void Start () {
		enemyHealth = enemyStartHealth;
		if (sleepTime > 0f) {
			StartCoroutine (Rest ());
		}
		StartCoroutine(Shooting());
		StartCoroutine(Decay());
	}
	
	// Update is called once per frame
	void Update () {
		if (Awake) {
			if (enemyHealth <= 0) {
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (this.gameObject);
			}
			transform.Translate (movement);
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (Awake) {
			if ((coll.gameObject.CompareTag ("PlayerBullet")) && invincible == false) {
				coll.gameObject.SetActive (false);
				Instantiate (hitExplosion, transform.position, transform.rotation);
				enemyHealth -= 10;
			}
		}
	}

	IEnumerator Rest() {
		Awake = false;
		yield return new WaitForSeconds (sleepTime);
		Awake = true;
	}

	IEnumerator Shooting() {
		yield return new WaitUntil (() => Awake);
		AudioSource audio = GetComponent<AudioSource> ();
		while (true) {
			yield return new WaitForSeconds(Random.Range(shootLow,shootHigh));
			audio.Play();
			Instantiate (enemyBullet, transform.position, transform.rotation);
		}
	}
	IEnumerator Decay() {
		yield return new WaitUntil (() => Awake);
		yield return new WaitForSeconds (Life);
		Destroy (this.gameObject);
	}
}
