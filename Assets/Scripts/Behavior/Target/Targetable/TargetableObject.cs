using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Collider2D))] // Required for collision with ITarget

	public class TargetableObject : MonoBehaviour, ITargetable {
		private string _name;
		private string _tag;
		private int _layer;
		private int _id;
		private GameObject _gameObject;

		void Start() {
			_name = this.gameObject.name;
			_tag = this.gameObject.tag;
			_layer = this.gameObject.layer;
			_id = this.GetInstanceID();
			_gameObject = this.gameObject;
		}

		/*
		 * User Functions
		 */

		public string getName() {
			return _name;
		}

		public string getTag() {
			return _tag;
		}

		public int getLayer() {
			return _layer;
		}

		public int getId() {
			return _id;
		}

		public GameObject getGameObject() {
			return _gameObject;
		}
	}
}
