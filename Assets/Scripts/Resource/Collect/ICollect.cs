using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface ICollect<T> {
		bool collect(ICollectible<T> collectible); // Returns if collected or not (must check if container is full, etc)
	}
}