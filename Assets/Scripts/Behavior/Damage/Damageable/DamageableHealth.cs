using UnityEngine;
using System.Collections;
using ScopeCreep.Resource;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Collider2D))] // Required for collision with IDamage

	public class DamageableHealth : MonoBehaviour, IDamageable {
		private IContainer healthContainer;

		void Start() {
			healthContainer = GetComponentInChildren<ICargoHold>().getContainer(ResourceType.HEALTH);
		}

		public void damage(IDamage damager) {
			float amount = damager.getAmount();

			healthContainer.remove(amount);

			if (healthContainer.isEmpty()) {
				die();
			}
		}

		public void die() {
			Destroy(this.gameObject); // Must be on top level game object!
		}

		public float getHealth() {
			return healthContainer.getAmount();
		}

		public void heal(IHeal healer) {
			float amount = healer.getAmount();

			healthContainer.add(amount);
		}
	}
}