using UnityEngine;
using System.Collections;

public class FadeForCredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("MusicManager").SendMessage ("StartFadeForCredits");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
