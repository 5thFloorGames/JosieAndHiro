using UnityEngine;
using System.Collections;

public class VisibleAndLitOnTrigger : MonoBehaviour {

	private Light[] lightSources;
	private bool hit = false;
	public Player activatableBy;

	void Start () {
		lightSources = GetComponentsInChildren<Light> ();
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if (!hit && checkPlayer(other)) {
			gameObject.GetComponent<AudioSource> ().loop = false;
			gameObject.GetComponent<AudioSource> ().PlayOneShot(Resources.Load<AudioClip>("Audio/projectoron"));

			foreach(Light lightSource in lightSources){
				lightSource.enabled = true;
			}
			hit = true;
		}
	}

	private bool checkPlayer(Collider other){
		if (activatableBy == Player.Hiro) {
			return other.tag == "Hiro";
		} else if (activatableBy == Player.Josie) {
			return other.tag == "Josie";
		} else {
			return (other.tag == "Hiro" || other.tag == "Josie");
		}
	}
}
