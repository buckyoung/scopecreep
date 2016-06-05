using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.System {
	public class FramesPerSecond : MonoBehaviour {
		public bool showFPS = true;
		public float sampleDelay = 0.5f;

		private int fps = 0;

		void Awake () {
			// Make the game run as fast as possible in Windows
			Application.targetFrameRate = 60;
		}

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
}