using UnityEngine;
using System.Collections;

public class StartLayerOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("MusicManager").SendMessage ("FadeInOne");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
