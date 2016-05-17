using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public bool isDreadnought;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isDreadnought) {
			transform.localScale = new Vector3 ((Boss.bossHealth / 1250f), .25f, 1f);
		} else {
			transform.localScale = new Vector3 ((MoveScript.playerHealth / 12.5f), .25f, 1f);
		}
	}
}
