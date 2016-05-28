using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module {
	public class ResourceManager : MonoBehaviour {
		public static void collect(IResourceHandler resourceHandler, Collectible.Collectible collectible) {
			switch(collectible.type) {
				case Collectible.Collectible.CollectibleType.SPACEDOLLARS:
					resourceHandler.addSpaceDollars(1.0f);
					break;
			}
		}
	}
}