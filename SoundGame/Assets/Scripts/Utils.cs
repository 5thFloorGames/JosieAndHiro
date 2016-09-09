using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utils{

	// Thanks Samu
	public static void Shuffle<T>(this IList<T> list, int seed = -1) {
		System.Random rng;
		if (seed != -1) rng = new System.Random(seed);
		else rng = new System.Random();

		int n = list.Count;
		while (n > 1) {
			n--;
			int k = rng.Next(n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
}
