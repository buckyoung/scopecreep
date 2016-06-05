using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface ITarget<T> {
		T getTarget();
		void setTarget(T target);
		void clearTarget();
	}
}