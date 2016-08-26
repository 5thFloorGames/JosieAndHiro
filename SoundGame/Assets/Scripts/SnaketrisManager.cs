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
		availableTiles = LockColors ();
		if (availableTiles.Count == 0) {
			print ("YOU WIN!");
		} else {
			SetBlock ();
		}
	}
	
	List<GameObject> LockColors(){
		List<GameObject> soundTiles = new List<GameObject> ();
		foreach (GameObject g in allTiles) {
			g.GetComponent<ColorOnTrigger> ().LockColor ();
			if (!g.GetComponent<ColorOnTrigger>().green) {
				soundTiles.Add (g);
			}
		}
		return soundTiles;
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
