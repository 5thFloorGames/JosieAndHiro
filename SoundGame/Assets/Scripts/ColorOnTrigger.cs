using UnityEngine;
using System.Collections;

public class ColorOnTrigger : MonoBehaviour {

	public bool green = false;
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
			if (!green) {
				GetComponent<Renderer> ().material.color = Color.green;
			} else {
				GetComponent<Renderer> ().material.color = Color.white;
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
			if (!green) {
				GetComponent<Renderer> ().material.color = Color.white;
			} else {
				GetComponent<Renderer> ().material.color = Color.green;
			}
		}
	}

	public bool LockColor(){
		if (active && !green) {
			green = true;
			return true;
		} else if (active && green) {
			return false;
		}
		return false;
	}
}
