using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnaketrisManager : MonoBehaviour {

	List<GameObject> allTiles;
	List<GameObject> availableTiles;
	GameObject soundBlock;

	// Use this for initialization
	void Start () {
		allTiles = new List<GameObject> ();
		allTiles.AddRange (GameObject.FindGameObjectsWithTag ("Unlit"));
		availableTiles = new List<GameObject> ();
		availableTiles.AddRange (GameObject.FindGameObjectsWithTag ("Unlit"));
		SetBlock ();
	}

	IEnumerator NextSound (Collider hiro){
		yield return new WaitForSeconds (0.5f);
		hiro.SendMessage ("Click");
		soundBlock.GetComponent<MakeSound> ().playSound = false;
		LockColors ();
		SetBlock ();
	}
	
	void LockColors(){
		foreach (GameObject g in allTiles) {
			if (g.GetComponent<ColorOnTrigger> ().LockColor ()) {
				availableTiles.Remove (g);
			}
		}
	}

	void SetBlock(){
		soundBlock = availableTiles [Random.Range (0,availableTiles.Count)];
		soundBlock.GetComponent<MakeSound> ().playSound = true;
	}

	public void CheckTile(GameObject tile, Collider hiro){
		if (tile == soundBlock) {
			StartCoroutine (NextSound(hiro));
		}
	}

	public void removeFromAvailableTiles(GameObject tile){
		availableTiles.Remove (tile);
	}
}
