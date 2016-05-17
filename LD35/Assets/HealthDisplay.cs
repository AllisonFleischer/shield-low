using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	public bool isDreadnought;

	private Text txtRef;

	// Use this for initialization
	void Start () {
		txtRef = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDreadnought) {
			txtRef.text = "DREADNOUGHT SHIELD: " + Boss.bossHealth;
		} else {
			txtRef.text = "Your SHIELD: " + MoveScript.playerHealth;
		}
	}
}
