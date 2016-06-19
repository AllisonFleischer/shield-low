using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public float fadeWait;
	public float startSpeed;

	public int MaxHealth = 10000;
	[HideInInspector] static public int bossHealth;

	public GameObject bg;

	public GameObject normalBullet;
	public GameObject leftBullet;
	public GameObject rightBullet;
	public GameObject midLeftBullet;
	public GameObject midRightBullet;
	public GameObject finalBullet;

	public GameObject explosion;
	public GameObject bigExplosion;

	public AudioSource pew;

	public Sprite damaged;

	private float bgalpha = 0f;
	private float thisred = 0f;
	private int bgfade = 0;
	private int currentAttack = 0;

	// Use this for initialization
	void Start () {
		bossHealth = MaxHealth;
		SpriteRenderer thisSpr = GetComponent<SpriteRenderer> ();
		StartCoroutine (FadeStart ());
		StartCoroutine (AttackPattern ());
		thisSpr.color = new Color (0f, 0f, 0f, 1f);
	}

	void FixedUpdate () {
		if (bgalpha < 1f && bgfade == 1) {
			bgalpha += 0.001f;
			SpriteRenderer bgrender = bg.GetComponent<SpriteRenderer> ();
			bgrender.color = new Color (.125f, 0f, 0f, bgalpha);
		} else if (bgalpha >= 1f && bgfade == 1 && transform.position.y > 5.5f) {
			transform.Translate (Vector3.down * Time.deltaTime * startSpeed);
		} else if (transform.position.y <= 5.5f && thisred < 1f) {
			bgfade = 2;
			bgalpha = bgalpha - 0.01f;
			thisred += 0.01f;
			SpriteRenderer bgrender = bg.GetComponent<SpriteRenderer> ();
			bgrender.color = new Color (.125f, 0f, 0f, bgalpha);
			SpriteRenderer thisSpr = GetComponent<SpriteRenderer> ();
			thisSpr.color = new Color (thisred, thisred, thisred, 1f);
		} else if (thisred >= 1f) {
			//NORMAL BOSS FUNCTIONS GO HERE!
			if (currentAttack == 1) {
				pew.Play ();
				TripleFire ();
				TripleFireOffset (5f);
				TripleFireOffset (-5f);
			}
			if (currentAttack == 2) {
				pew.Play ();
				TripleFire ();
			}
			if (currentAttack == 3) {
				pew.Play ();
				DoubleFire ();
			}
			if (currentAttack == 4) {
				pew.Play ();
				DoubleFire ();
				DoubleFireOffset (5f);
				DoubleFireOffset (-5f);
			}
			if (currentAttack == 5) {
				pew.Play ();
				Fire ();
			}

			if (currentAttack == 6) {
				pew.Play ();
				FireOffset (0f);
				FireOffset (2f);
				FireOffset (4f);
				FireOffset (6f);
				FireOffset (8f);
				FireOffset (-2f);
				FireOffset (-4f);
				FireOffset (-6f);
				FireOffset (-8f);
			}
		}
	}
		
	IEnumerator FadeStart() {
		yield return new WaitForSeconds (fadeWait);
		bgfade = 1;
	}

	IEnumerator AttackPattern() {
		yield return new WaitUntil (() => (thisred >= 1f));
		currentAttack = 5;
		yield return new WaitForSeconds (7f);
		currentAttack = 0;
		yield return new WaitForSeconds (2f);
		currentAttack = 2;
		yield return new WaitForSeconds (7f);
		currentAttack = 0;
		yield return new WaitForSeconds (2f);
		currentAttack = 1;
		yield return new WaitForSeconds (5f);
		currentAttack = 0;
		yield return new WaitForSeconds (2f);
		currentAttack = 3;
		yield return new WaitForSeconds (2.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (2.5f);
		currentAttack = 0;
		yield return new WaitForSeconds (2f);

		currentAttack = 1;
		yield return new WaitForSeconds (1f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (1f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 1;
		yield return new WaitForSeconds (1f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (1f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);

		currentAttack = 1;
		yield return new WaitForSeconds (.5f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (.5f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 1;
		yield return new WaitForSeconds (.5f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (.5f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);

		currentAttack = 1;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 1;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 1;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 1;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (.5f);
		currentAttack = 4;
		yield return new WaitForSeconds (.25f);
		currentAttack = 0;
		yield return new WaitForSeconds (2f);

		currentAttack = 6;
		yield return new WaitUntil (() => (bossHealth <= 0));
		currentAttack = 0;
		bossHealth = 0;

		GetComponent<SpriteRenderer> ().sprite = damaged;
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);
		Instantiate (explosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (.25f);

		Instantiate (bigExplosion, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

	void Fire() {
		bossHealth = bossHealth - 1;
		Instantiate(normalBullet, transform.position, transform.rotation);
	}

	void FireOffset(float offset) {
		bossHealth = bossHealth - 1;
		Vector3 off = new Vector3 (offset, 0);
		Instantiate(finalBullet, transform.position + off, transform.rotation);
	}

	void TripleFire() {
		bossHealth = bossHealth - 3;
		Instantiate(finalBullet, transform.position, transform.rotation);
		Instantiate(leftBullet, transform.position, transform.rotation);
		Instantiate(rightBullet, transform.position, transform.rotation);
	}

	void TripleFireOffset(float offset) {
		bossHealth = bossHealth - 3;
		Vector3 off = new Vector3 (offset, 0);
		Instantiate(normalBullet, transform.position + off, transform.rotation);
		Instantiate(leftBullet, transform.position + off, transform.rotation);
		Instantiate(rightBullet, transform.position + off, transform.rotation);
	}

	void DoubleFire() {
		bossHealth = bossHealth - 2;
		Instantiate(midLeftBullet, transform.position, transform.rotation);
		Instantiate(midRightBullet, transform.position, transform.rotation);
	}

	void DoubleFireOffset(float offset) {
		bossHealth = bossHealth - 2;
		Vector3 off = new Vector3 (offset, 0);
		Instantiate(midLeftBullet, transform.position + off, transform.rotation);
		Instantiate(midRightBullet, transform.position + off, transform.rotation);
	}
}