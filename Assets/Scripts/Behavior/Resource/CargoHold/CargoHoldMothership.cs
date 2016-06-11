using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ScopeCreep.Resource {
	public class CargoHoldMothership : MonoBehaviour, ICargoHold {
		public Dictionary<ResourceType, IContainer> cargoHold = new Dictionary<ResourceType, IContainer>();
		
	}
}