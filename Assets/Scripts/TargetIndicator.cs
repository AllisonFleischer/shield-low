using UnityEngine;
using System.Collections;

public class TargetIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = MoveScript.bulletTarget;
	}
}
