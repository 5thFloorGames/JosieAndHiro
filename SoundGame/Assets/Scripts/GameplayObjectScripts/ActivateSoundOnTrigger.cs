using UnityEngine;
using System.Collections;

public class ActivateSoundOnTrigger : MonoBehaviour {

	public MakeSound sound;

	void OnTriggerEnter(Collider other){
		sound.playSound = true;
	}

	void OnTriggerExit(Collider other){
		sound.playSound = false;
	}
}
