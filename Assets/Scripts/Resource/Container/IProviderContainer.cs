using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface IProviderContainer : IContainer {
		ProviderType getProviderType();
	}
}
