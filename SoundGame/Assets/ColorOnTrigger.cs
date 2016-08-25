using UnityEngine;
using System.Collections;

public class ColorOnTrigger : MonoBehaviour {

	private bool colorLocked = false;
	private bool failed = false;
	private bool active = false;
	[SerializeField]
	private Player activePlayer = Player.None;
	private SnaketrisManager manager;

	void Start (){
		manager = FindObjectOfType<SnaketrisManager> ();
	}

	void OnTriggerEnter(Collider col){
		if (!active) {
			active = true;
			activePlayer = (Player)System.Enum.Parse (typeof(Player), col.tag);
			if (!colorLocked) {
				GetComponent<Renderer> ().material.color = Color.green;
			} else {
				GetComponent<Renderer> ().material.color = Color.red;
			}
			if (col.tag == "Hiro") {
				manager.CheckTile (gameObject, col);
			}
		} else {
			activePlayer = Player.Both;
		}
	}

	void OnTriggerExit(Collider col){
		if (activePlayer == Player.Both) {
			if (col.tag == "Hiro") {
				activePlayer = Player.Josie;
			} else {
				activePlayer = Player.Hiro;
			}
		} else if (col.tag == activePlayer.ToString ()) {
			active = false;
			activePlayer = Player.None;
			if (!colorLocked) {
				GetComponent<Renderer> ().material.color = Color.white;
			} else if (colorLocked && !failed) {
				GetComponent<Renderer> ().material.color = Color.green;
			}
		}
	}

	public bool LockColor(){
		if (active && !colorLocked) {
			colorLocked = true;
			return true;
		} else if (active && colorLocked) {
			failed = true;
			return false;
		}
		return false;
	}
}
