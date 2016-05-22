using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown("p")) {
			GameObject resource = (GameObject)Instantiate(Resources.Load("ResourcePrefab"), new Vector3(0, 52, 0), Quaternion.identity);
			resource.transform.localScale = new Vector3 (1, 1, 1);
		}
	}
}
