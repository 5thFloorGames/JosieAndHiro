using UnityEngine;
using System.Collections;

public class MemoryGamePiece : MonoBehaviour {

	public Animal animal;
	public CardType type;
	private Texture[] animalMaterials;
	private Texture white;
	private Texture audio;

	// Use this for initialization
	void Start () {
		animalMaterials = Resources.LoadAll<Texture>("Textures/AnimalTextures");
		white = Resources.Load<Texture>("Textures/white");
		audio = Resources.Load<Texture>("Textures/Audio");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (type == CardType.Visual) {
			GetComponent<MeshRenderer> ().material.mainTexture = animalMaterials [(int)animal];
		} else {
			GetComponent<MeshRenderer> ().material.mainTexture = audio;
		}
	}

	void OnTriggerExit(Collider col){
		GetComponent<MeshRenderer> ().material.mainTexture = white;
	}
}
