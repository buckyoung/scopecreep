using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface IDamageable {
		void damage(IDamage damager);
		void die();
		float getHealth();
		void heal(IHeal healer);
	}
}