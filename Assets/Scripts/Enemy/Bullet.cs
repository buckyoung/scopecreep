using UnityEngine;
using System.Collections;

namespace ScopeCreep.Enemy.Bullet {
	public class Bullet : MonoBehaviour {
		void Start () {
		
		}
		void Update () {
		
		}

		void OnCollisionEnter2D(Collision2D col) {
			if ( col.gameObject.layer != LayerMask.NameToLayer("Enemy") ) {
				Destroy(this.gameObject);
			}
		}
	}
}