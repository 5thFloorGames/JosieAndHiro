using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateGrid : MonoBehaviour {

	public int xAmount = 5;
	public int yAmount = 5;
	public Transform secondGrid;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < xAmount; i++){
			for(int j = 0; j < yAmount; j++){
				GameObject cube = (GameObject)Instantiate (Resources.Load ("GamePlay Objects/HiroGridBlock"), transform.position + new Vector3 (i, 0, j), Quaternion.identity);
				cube.transform.parent = transform;
				GameObject basicCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				basicCube.transform.position = secondGrid.transform.position + new Vector3 (i, 0, j);
				basicCube.transform.parent = secondGrid;
				cube.GetComponent<ChangeCubeColor> ().cube = basicCube;
			}
		}
	}

}
