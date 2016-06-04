﻿using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface IDamageable {
		void damage(float amount);
		void die();
		float getMetric();
		void heal(float amount);
	}
}