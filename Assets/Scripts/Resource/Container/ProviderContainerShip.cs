using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public class ProviderContainerShip : IProviderContainer {
		private ResourceType resourceType;
		private ProviderType providerType;
		private float amount;
		private float maximum;

		public ProviderContainerShip(ResourceType resourceType, ProviderType providerType, float initialAmount, float maximumCapacity) {
			this.resourceType = resourceType;
			this.providerType = providerType;
			amount = initialAmount;
			maximum = maximumCapacity;

			// Ensure valid values
			if (maximum < 0) {
				maximum = 0;
			}

			if (amount < 0) {
				amount = 0;
			} else if (amount > maximum) {
				amount = maximum;
			}
		}

		// Returns the amount actually added
		public float add(float amount) {
			if (amount < 0) {
				Debug.LogWarning("Warning: amount cannot be less than 0");
				return 0.0f;
			}

			this.amount += amount;

			if (this.amount > maximum) {
				float overflow = this.amount - maximum;
				this.amount = maximum;
				return amount - overflow;
			}

			return amount;
		}

		// Returns the amount actually taken out
		public float remove(float amount) {
			if (amount < 0) {
				Debug.LogWarning("Warning: amount cannot be less than 0");
				return 0.0f;
			}

			this.amount -= amount;

			if (this.amount < 0) {
				float underflow = 0 - this.amount;
				this.amount = 0;
				return amount - underflow;
			}

			return amount;
		}

		public float getAmount() {
			return amount;
		}

		public float getCapacity() {
			return maximum;
		}

		public bool isFull() {
			return amount == maximum;
		}

		public bool isEmpty() {
			return amount == 0;
		}

		public ResourceType getResourceType() {
			return resourceType;
		}

		public ProviderType getProviderType() {
			return providerType;
		}
	}
}
