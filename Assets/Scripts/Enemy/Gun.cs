using UnityEngine;
using System.Collections;

namespace Enemy.Gun {
	public class Gun : MonoBehaviour {
		public GameObject target = null;
		public int ammo = 100;
		public float speed = 5;

		// Use this for initialization
		void Start() {
		}
		
		// Update is called once per frame
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
			}
		}

		private void OnTriggerExit2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = null;
			}
		}
	}
}
