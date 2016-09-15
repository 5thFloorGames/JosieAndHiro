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
	private bool soundPlaying = false;

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
		if (!sound.isPlaying && sound.enabled && soundPlaying && !locked && active) {
			Sound ();
		}
	}

	void Sound(){
		sound.clip = sounds[Random.Range(0, sounds.Length)];
		sound.Play();
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
					if (col.tag == "Hiro") {
						StartCoroutine(PlaySound (0.7f, col));
					} else {
						StartCoroutine(PlaySound (0f, col));
					}
				}
			}
		} else {
			activePlayer = Player.Both;
		}
	}
	IEnumerator PlaySound(float delay, Collider col){
		yield return new WaitForSeconds (delay);
		soundPlaying = true;
		Sound ();
		if (locked && col.tag == "Hiro") {
		    yield return new WaitForSeconds (0.3f);
			col.SendMessage ("Click");
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
			soundPlaying = false;
		}
	}

	IEnumerator PlayClick(){
		yield return new WaitForSeconds (0.8f);
		GameObject.FindGameObjectWithTag ("Hiro").SendMessage ("Click");
	}
		

	public void Lock(){
		locked = true;
		if (!soundPlaying) {
			StartCoroutine (PlayClick ());
		}
	}

}
