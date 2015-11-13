using UnityEngine;
using System.Collections;

public class VisibleAndLitOnTrigger : MonoBehaviour {

	private Light lightSource;

	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		lightSource = GetComponentInChildren<Light> ();
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		gameObject.GetComponent<AudioSource> ().loop = false;
		lightSource.enabled = true;
	}
}
