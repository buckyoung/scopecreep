using UnityEngine;
using System.Collections;

public class FramesPerSecond : MonoBehaviour {
	public bool showFPS = true;
	public float sampleDelay = 0.5f;

	private int fps = 0;

	void Start() {
		StartCoroutine( calculateFPS() );
	}

	void OnGUI() {
		if (showFPS) {
			GUI.Label(new Rect(0, 0, 100, 100), fps.ToString()); 
		}
	}

	private IEnumerator calculateFPS() {
		while(true) {
			fps = ((int)(1.0f / Time.smoothDeltaTime)); 

			fps = fps < 0 ? 0 : fps; // Min value 0

			yield return new WaitForSeconds(sampleDelay);
		}
	}
}
