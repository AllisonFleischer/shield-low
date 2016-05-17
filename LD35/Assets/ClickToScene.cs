using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickToScene : MonoBehaviour {

	public string SceneToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneToLoad);
		}
	}
}
