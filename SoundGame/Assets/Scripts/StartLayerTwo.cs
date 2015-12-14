using UnityEngine;
using System.Collections;

public class StartLayerTwo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("MusicManager").SendMessage ("FadeInTwo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
