using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateGrid : MonoBehaviour {

	public int xAmount = 5;
	public int yAmount = 5;
	public Transform secondGrid;
	public bool vertical = false;
	public GameObject gridBlock;
	public int spacingMultiplier = 1;
	public bool soundNavigation;

	// Use this for initialization
	void Start () {
		if (gridBlock == null) {
			gridBlock = (GameObject) GameObject.CreatePrimitive (PrimitiveType.Cube);
		}
		for(int i = 0; i < xAmount; i++){
			for(int j = 0; j < yAmount; j++){
				GameObject cube = (GameObject)Instantiate (Resources.Load ("GamePlay Objects/HiroGridBlock"), transform.position + new Vector3 (i, 0, j), Quaternion.identity);
				cube.transform.parent = transform;
				GameObject basicCube = (GameObject) Instantiate(gridBlock);
				if (vertical) {
					basicCube.transform.position = secondGrid.transform.position + new Vector3 (spacingMultiplier * i, spacingMultiplier *  j, 0);
				} else {
					basicCube.transform.position = secondGrid.transform.position + new Vector3 (spacingMultiplier *  i, 0, spacingMultiplier *  j);
				}
				basicCube.transform.parent = secondGrid;
				cube.GetComponent<ChangeCubeColor> ().cube = basicCube;
				if (soundNavigation) {
					if (i == 0 && j == yAmount - 1) {
						CreateTriggerAndSound ("Dog", transform.position + new Vector3 (i, 0, j), secondGrid.transform.position + new Vector3 (spacingMultiplier * i, 0.5f, spacingMultiplier * j));
					} else if (i == xAmount - 1 && j == 0){
						CreateTriggerAndSound ("Cat", transform.position + new Vector3 (i, 0, j), secondGrid.transform.position + new Vector3 (spacingMultiplier * i, 0.5f, spacingMultiplier * j));
					} else if (i == xAmount - 1 && j == yAmount - 1){
						CreateTriggerAndSound ("Cow", transform.position + new Vector3 (i, 0, j), secondGrid.transform.position + new Vector3 (spacingMultiplier * i, 0.5f, spacingMultiplier * j));
					}
				}
					
			}
		}
		if (vertical) {
			secondGrid.Rotate (180, 0, 0);
		}
	}

	void CreateTriggerAndSound(string animalName, Vector3 firstPosition, Vector3 secondPosition){
		GameObject button = (GameObject)Instantiate (Resources.Load ("GamePlay Objects/SoundNavigation/" + animalName + "/Trigger"), secondPosition, Quaternion.Euler(-90,0,180));
		GameObject soundBlock = (GameObject)Instantiate (Resources.Load ("GamePlay Objects/SoundNavigation/" + animalName + "/Sound"), firstPosition, Quaternion.identity);
		button.GetComponent<ActivateSoundOnTrigger> ().sound = soundBlock.GetComponent<MakeSound> ();
	}

}
