﻿using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Collectible {
	public class Collectible : MonoBehaviour {
		public enum CollectibleType{
			SPACEDOLLARS,
			TEST
		};

		public CollectibleType type;
	}
}