using UnityEngine;
using System.Collections;

public class ClickOnTrigger : MonoBehaviour {

	public AudioClip click;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		StartCoroutine ("Click");
	}

	IEnumerator Click(){
		yield return new WaitForSeconds (0.7f);
		sound.PlayOneShot (click, 1f);
	}
	
}
