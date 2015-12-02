using UnityEngine;
using System.Collections;

public class VisibleAndLitOnTrigger : MonoBehaviour {

	private Light lightSource;
	private bool hit = false;

	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		lightSource = GetComponentInChildren<Light> ();
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if (!hit && other.tag == "Hiro") {
			gameObject.GetComponent<AudioSource> ().loop = false;
			lightSource.enabled = true;
			hit = true;
		}
	}
}
