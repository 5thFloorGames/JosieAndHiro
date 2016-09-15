using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryGameManager : MonoBehaviour {

	private int pairCount = 0;
	private int maxPairs = 8;
	private List<MemoryGamePiece> pieces;
	private bool done = false;

	void Start(){
		pieces = new List<MemoryGamePiece> ();
		pieces.AddRange(FindObjectsOfType<MemoryGamePiece>());
		pieces.Shuffle ();
		List<Animal> animals = new List<Animal> ();		
		print (pieces.Count);

		for (int i = 0; i < maxPairs * 2; i+=2) {
			Animal nimal = (Animal)Random.Range(0,3);
			pieces [i].animal = nimal;
			pieces [i].type = CardType.Audio;
			pieces [i + 1].animal = nimal;
			pieces [i + 1].type = CardType.Visual;
		}
		pieces.Clear ();
	}

	public void addPiece(MemoryGamePiece piece){
		pieces.Add (piece);
		if (pieces.Count == 2) {
			if (pieces [0].animal == pieces [1].animal && pieces [0].type != pieces [1].type) {
				foreach(MemoryGamePiece lockable in pieces){
					lockable.Lock ();
				}
				pieces.Clear ();
				pairCount++;
				if (pairCount == maxPairs) {
					done = true;
					print ("WOOOOOOOO!");
				}
			}
		}

	}

	public void removePiece(MemoryGamePiece piece){
		pieces.Remove (piece);
	}
}
