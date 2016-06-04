using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public interface ITargetable {
		string getName();
		string getTag();
		int getLayer();
		int getId();
		GameObject getGameObject();
	}
}