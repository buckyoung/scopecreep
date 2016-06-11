using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ScopeCreep.Resource {
	public interface ICargoHold {
		IContainer getContainer(ResourceType type);
	}
}
