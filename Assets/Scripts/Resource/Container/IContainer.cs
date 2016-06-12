using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public interface IContainer {
		float add(float amount); // Returns amount actually added
		float remove(float amount); // Returns amount actually subtracted
		float getAmount(); // Returns amount in the container
		float getCapacity(); // Returns maximum allowed in container
		bool isFull();
		bool isEmpty();
		ResourceType getResourceType();
	}
}
