using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Collectible {
	public class Resource : MonoBehaviour {
		public enum ResourceType{
			SPACEDOLLARS,
			FUEL
		};

		public ResourceType type;
	}
}