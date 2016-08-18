using UnityEngine;
using System.Collections;

public class VisibleOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		gameObject.GetComponent<AudioSource> ().loop = false;
	}
}
