using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface IAimable<T> {
		void aimAt(T target);
	}
}