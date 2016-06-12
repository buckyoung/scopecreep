using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface ICollect {
		bool collect(ICollectible collectible); // Returns if collected or not (used to determine if should destroy collected object)
	}
}