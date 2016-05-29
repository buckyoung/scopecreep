using UnityEngine;
using System.Collections;

namespace ScopeCreep.System {
	public class ButtonEventManager : MonoBehaviour {
		// Events
		public delegate void ButtonDownEvent(ButtonEventManager eventObject, int playerId);
		public static event ButtonDownEvent onAButtonDown;
		public static event ButtonDownEvent onXButtonDown;
		public static event ButtonDownEvent onDebugButtonDown;

		void Update() {
			// P1 & 2: Button A
			for(int i = 1; i <= 2; i++) {
				if (Input.GetButtonDown(i + "_BTN_A")) {
					if (onAButtonDown != null) onAButtonDown(this, i);
				}
			}

			// P1 & 2: Button X
			for(int i = 1; i <= 2; i++) {
				if (Input.GetButtonDown(i + "_BTN_X")) {
					if (onXButtonDown != null) onXButtonDown(this, i);
				}
			}

			// Debug button
			if (Input.GetButtonDown("DebugButton")) {
				if (onDebugButtonDown != null) onDebugButtonDown(this, 0);
			}
		}

	}
}