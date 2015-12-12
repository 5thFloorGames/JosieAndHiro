using UnityEngine;
using System.Collections;

public class PlayClickTrigger : MonoBehaviour {

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		StartCoroutine(ClickAndOpen(other));
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
