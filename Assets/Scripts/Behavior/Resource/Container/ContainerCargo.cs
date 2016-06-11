﻿using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public class ContainerCargo<T> : MonoBehaviour {
		private float amount;
		private float maximum;

		public ContainerCargo(float initialAmount, float maximumCapacity) {
			amount = initialAmount;
			maximum = maximumCapacity;
		}

		// Returns the amount actually added
		public float add(float amount) {
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

		public float getMaximumCapacity() {
			return maximum;
		}
	}
}
