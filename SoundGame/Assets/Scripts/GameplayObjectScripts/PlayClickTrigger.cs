using UnityEngine;
using System.Collections;

public class PlayClickTrigger : MonoBehaviour {

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		StartCoroutine(ClickAndOpen(other));
		transform.Translate(new Vector3(0f,0f,-0.1f));
	}

	void OnTriggerExit(Collider other){
		transform.Translate(new Vector3(0f,0f,0.1f));
	}
		

	IEnumerator ClickAndOpen(Collider other){
		if (other.tag == "Hiro") {
			yield return new WaitForSeconds(0.75f);
			other.SendMessage ("Click");
		} else {
			yield return new WaitForSeconds(0.1f);
			sound.PlayOneShot(sound.clip);
		}
	}
}
