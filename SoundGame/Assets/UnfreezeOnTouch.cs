using UnityEngine;
using System.Collections;

public class UnfreezeOnTouch : MonoBehaviour {

	private FreezeOnTouch freeze;

	// Use this for initialization
	void Start () {
		freeze = FindObjectOfType<FreezeOnTouch> ();
	}
	
	void OnTriggerEnter(Collider col){
		freeze.Unfreeze ();
	}
}
