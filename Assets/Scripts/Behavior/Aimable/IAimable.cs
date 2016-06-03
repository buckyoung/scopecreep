using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface IAimable {
		void aimAt(GameObject target);
	}
}