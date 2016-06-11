using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface ICollectible<T> {
		float getAmount();
		T getType();
	}
}
