﻿using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface IDamage {
		float getAmount();
		void setAmount(float amount);
	}
}