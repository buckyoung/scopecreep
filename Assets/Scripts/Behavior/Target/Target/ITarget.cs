using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface ITarget {
		ITargetable getTarget();
		void setTarget(ITargetable target);
		void clearTarget();
	}
}