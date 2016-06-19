using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float waitTime;
	public bool isPlayer;
	public bool isBoss;

	// Use this for initialization
	void Start () {
		StartCoroutine (Disappear ());
	}
	
	IEnumerator Disappear() {
		yield return new WaitForSeconds (waitTime);
		if (isPlayer) {
			SceneManager.LoadScene ("main");
		} else if (isBoss) {
			SceneManager.LoadScene ("outro1");
		} else {
			Destroy (this.gameObject);
		}
	}
}
