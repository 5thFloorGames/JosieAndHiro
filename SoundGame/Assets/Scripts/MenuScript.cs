using UnityEngine;
using UnityEditor;
using System.Collections;

public class MenuScript : MonoBehaviour{
	
	[MenuItem ("Craziness/Create a Grid")]
	static void DoSomething () {
		int [][] grid = new int[5][];

		int x = Random.Range (1,4);
		int y = Random.Range (1,4);

		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				GameObject parent = GameObject.FindGameObjectWithTag ("Grid");
				GameObject newTile;
				if(distance (x,y,i,j) == 0){
					newTile = (GameObject)PrefabUtility.InstantiatePrefab (Resources.Load ("SoundWinBlock"));
				} else {
					newTile = (GameObject)PrefabUtility.InstantiatePrefab (Resources.Load ("SoundBlock"));
				}
				newTile.transform.position = parent.transform.position + new Vector3 (i * 1f, 0, j * -1f);
				newTile.transform.parent = parent.transform;
				newTile.GetComponent<AudioSource>().pitch = 1 - (distance(x,y,i,j))/10;
			}
		}
	}

	static float distance(int x1, int y1, int x2, int y2) {
		int dx = Mathf.Abs(x2 - x1);
		int dy = Mathf.Abs(y2 - y1);

		int min = Mathf.Min(dx, dy);
		int max = Mathf.Max(dx, dy);
		
		int diagonalSteps = min;
		int straightSteps = max - min;

		return (Mathf.Sqrt(2) * diagonalSteps + straightSteps);
	}
}
