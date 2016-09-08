using UnityEngine;
using System.Collections;

public class AdjustableMakeSound : MonoBehaviour {

	private AudioClip[] sounds;
	private AudioSource sound;
	public string path;
	public bool playSound = true;
	public float delay = 0;
	private bool soundPlaying = false;

	// Use this for initialization
	void Start () {
		sounds = Resources.LoadAll<AudioClip>("Audio/" + path);

		sound = GetComponentInChildren<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (!sound.isPlaying && !soundPlaying && sound.enabled && playSound) {
			StartCoroutine(Sound());
			soundPlaying = true;
		}
	}

	IEnumerator Sound(){
		sound.clip = sounds[Random.Range(0, sounds.Length)];
		yield return new WaitForSeconds (delay);
		sound.Play();
		soundPlaying = false;
	}
}