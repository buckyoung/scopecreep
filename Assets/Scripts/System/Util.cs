using UnityEngine;
using System.Collections;

namespace ScopeCreep.System {
	public class Util : MonoBehaviour {
		public static float angleSigned(Vector3 v1, Vector3 v2, Vector3 n) {
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
		}
	}
}
