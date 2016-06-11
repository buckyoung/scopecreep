using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface ICargoHold {
		IContainer getContainer(ResourceType type);
		void emptyContianerInto(IContainer destination); // TODO -- edgecases 
	}
}
