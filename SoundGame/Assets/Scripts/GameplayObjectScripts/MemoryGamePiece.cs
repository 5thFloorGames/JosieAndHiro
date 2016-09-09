using UnityEngine;
using System.Collections;

public class MemoryGamePiece : MonoBehaviour {

	public Animal animal;
	public CardType type;
	private Texture[] animalMaterials;
	private Texture white;
	private Texture audio;
	private AudioSource sound;
	private AudioClip[] sounds;
	private bool locked = false;
	private bool active = false;
	private MemoryGameManager manager;
	private Player activePlayer = Player.None;

	// Use this for initialization
	void Start () {
		animalMaterials = Resources.LoadAll<Texture>("Textures/AnimalTextures");
		white = Resources.Load<Texture>("Textures/white");
		audio = Resources.Load<Texture>("Textures/Audio");
		sounds = Resources.LoadAll<AudioClip>("Audio/Actions/" + animal);
		manager = FindObjectOfType<MemoryGameManager> ();

		sound = GetComponentInChildren<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (!active) {
			active = true;
			activePlayer = (Player)System.Enum.Parse (typeof(Player), col.tag);
			if (!locked) {
				manager.addPiece (this);
				if (type == CardType.Visual) {
					GetComponent<MeshRenderer> ().material.mainTexture = animalMaterials [(int)animal];
				} else {
					GetComponent<MeshRenderer> ().material.mainTexture = audio;
				}
				if (type == CardType.Audio) {
					sound.PlayOneShot (sounds [Random.Range (0, sounds.Length)]);
				}
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
			if (!locked) {
				manager.removePiece (this);
				GetComponent<MeshRenderer> ().material.mainTexture = white;
			}
		}
	}

	public void Lock(){
		locked = true;
	}
}
