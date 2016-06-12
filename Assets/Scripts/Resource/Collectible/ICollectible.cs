using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface ICollectible {
		float getAmount();
		ResourceType getType();
	}
}
