using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float speed = 1.0f;
	public float regenTime = .25f;
	public float reloadTime = .75f;
	public bool debugMode = false;
	public GameObject bullet;
	public GameObject playerHit;
	public GameObject playerExplosion;
	public GameObject smallExplosion;
	public int MaxHealth = 100;
	[HideInInspector] static public int playerHealth;
	public Sprite normalSprite;
	public Sprite powerSprite;
	public AudioSource pew;
	public AudioSource power;

	[HideInInspector] static public Pool pool;

	private bool canShoot = true;

	private Vector3 mousePos;
	private Vector3 objectPos;
	static public Vector3 bulletTarget;
	private float angle;

	// BUILT-IN UNITY FUNCTIONS:

	void Start () {
		playerHealth = MaxHealth;
		StartCoroutine(Regen());
	}

	void FixedUpdate () {
		if (playerHealth <= 0) {
			playerHealth = 0;
			Instantiate (playerExplosion, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}

		//Movement controls:
		float inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float inputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		/*GetComponent<Rigidbody2D>().AddForce(transform.up * inputY);
		GetComponent<Rigidbody2D>().AddForce(transform.right * inputX);*/
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,1) * inputY);
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (1,0) * inputX);

		//Shooting controls:
		if (Input.GetButton ("Fire1")) {
			if (canShoot) {
				pew.Play();
				Fire ();
				StartCoroutine (Reload ());
				GetComponent<SpriteRenderer> ().sprite = normalSprite;
			}
		} else if (Input.GetButton ("Fire2")) {
			if (playerHealth > 1) {
				pew.Play();
				Fire ();
				playerHealth--;
				GetComponent<SpriteRenderer> ().sprite = powerSprite;
			}
		} else {
			GetComponent<SpriteRenderer> ().sprite = normalSprite;
		}
	}

	void OnTriggerStay2D (Collider2D coll) {
		if (coll.gameObject.CompareTag ("EnemyBullet")) {
			Instantiate (playerHit, transform.position, transform.rotation);
			Destroy (coll.gameObject);
			if (!debugMode) {
				playerHealth -= 10;
			}
		} else if (coll.gameObject.CompareTag ("Powerup")) {
			power.Play();
			Destroy (coll.gameObject);
			playerHealth = MaxHealth;
		} else if (coll.gameObject.CompareTag ("BossBullet")) {
			Instantiate (smallExplosion, transform.position, transform.rotation);
			Destroy (coll.gameObject);
			if (!debugMode) {
				playerHealth -= 1;
			}
		}
	}

	void Update () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		//mousePos = mousePos / 10;
		//objectPos.x = objectPos.x - 16;
		bulletTarget = objectPos;
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
	}

	// OTHER FUNCTIONS:

	IEnumerator Regen () {
		while (true) {
			yield return new WaitForSeconds (regenTime);
			if (playerHealth < 100) {
				playerHealth++;
			}
		}
	}

	IEnumerator Reload () {
		canShoot = false;
		yield return new WaitForSeconds (reloadTime);
		canShoot = true;
	}

	void Fire() {
		//Instantiate (bullet, transform.position, transform.rotation);
	}
}
