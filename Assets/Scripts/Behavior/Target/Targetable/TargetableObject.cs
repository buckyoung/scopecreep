using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Collider2D))] // Required for collision with ITarget

	public class TargetableObject : MonoBehaviour, ITargetable {
		private GameObject _gameObject;

		void Start() {
			_gameObject = this.gameObject;
		}

		/*
		 * User Functions
		 */

		public GameObject getGameObject() {
			return _gameObject;
		}
	}
}
