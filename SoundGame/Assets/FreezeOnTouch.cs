using UnityEngine;
using System.Collections;

public class FreezeOnTouch : MonoBehaviour {

	private bool active = false;
	private GameObject frozen = null;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Josie") {
			active = true;
			frozen = col.gameObject;
			col.SendMessage ("Freeze");
		}
	}

	public void Unfreeze(){
		if (frozen != null) {
			frozen.SendMessage ("Unfreeze");
		}
	}

}
