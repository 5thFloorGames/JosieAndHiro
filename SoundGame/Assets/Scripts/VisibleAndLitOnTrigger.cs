using UnityEngine;
using System.Collections;

public class VisibleAndLitOnTrigger : MonoBehaviour {

	private Light lightSource;
	public GameObject canvas;
	public bool hit = false;

	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		lightSource = GetComponentInChildren<Light> ();
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if (!hit) {
			gameObject.GetComponent<MeshRenderer> ().enabled = true;
			gameObject.GetComponent<AudioSource> ().loop = false;
			lightSource.enabled = true;
			lightSource.transform.Rotate (Vector3.left, 30f);
			canvas.SetActive (true);
			hit = true;
		}
	}
}
