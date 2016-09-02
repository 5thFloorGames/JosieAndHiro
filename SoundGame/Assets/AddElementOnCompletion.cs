using UnityEngine;
using System.Collections;

public class AddElementOnCompletion : MonoBehaviour {

	public GameObject[] activatables;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Completed(){
		foreach (GameObject activatable in activatables) {
			activatable.SetActive (true);
		}
	}
}
