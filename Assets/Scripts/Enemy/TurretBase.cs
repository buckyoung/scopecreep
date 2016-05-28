using UnityEngine;
using System.Collections;

namespace ScopeCreep.Enemy.TurretBase {
	public class TurretBase : MonoBehaviour {
		public GameObject target = null;
		public float speed = 5;

		//Events
		public delegate void EnemyFoundEvent(TurretBase eventObject, bool isFound);
		public static event EnemyFoundEvent onEnemyFound;

		void Start() {
		}
		
		void Update() {
			if (target != null) {
				Vector3 vectorToTarget = target.transform.position - transform.position;
				float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, q, Time.deltaTime *speed);
			}
		}

		private void OnTriggerEnter2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = col.gameObject;
				onEnemyFound(this, true);
			}
		}

		private void OnTriggerExit2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = null;
				onEnemyFound(this, false);
			}
		}
	}
}
