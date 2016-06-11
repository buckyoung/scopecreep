using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Resource;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.Mothership {

	[RequireComponent (typeof (IDamageable))]
	[RequireComponent (typeof (ResourceHandler))]

	public class GUIHandler : MonoBehaviour {
		private IDamageable damageableBehavior;

		void Start() {
			damageableBehavior = GetComponent<IDamageable>();
		}

		void OnGUI() {
			GUI.Label(new Rect(Screen.width - 300, 10, 140, 30), "Health " + damageableBehavior.getHealth());
		}
	}
}