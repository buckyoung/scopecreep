using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.Mothership { 
	public class Movement : MonoBehaviour {
		public float speed = 0.02f;

		private Mothership mothership;

		void Start() {
			mothership = GameObject.Find("MothershipModule").GetComponent<Mothership>();
		}

		void Update() {
			int activePlayerId = mothership.activePlayerId;

			if (activePlayerId > 0) {
				transform.RotateAround(
					Vector3.zero, 
					Vector3.forward, 
					-speed * Input.GetAxis(activePlayerId + "_AXIS_X")
				);
			}
		}
	}
}