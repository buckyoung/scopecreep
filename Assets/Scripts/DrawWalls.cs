using UnityEngine;

public class DrawWalls : MonoBehaviour {
	private GameObject leftWall;
	private GameObject rightWall;

	void Start() {
		leftWall = transform.Find("LeftWall").gameObject;
		rightWall = transform.Find("RightWall").gameObject;
	}

	void Update() {
		// Get camera borders
		float leftBorder = transform.InverseTransformPoint(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0))).x;
		float rightBorder = transform.InverseTransformPoint(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0))).x;
		
		// Dynamically set the walls' positions
		leftWall.transform.localPosition = new Vector3(leftBorder - 1.0f, leftWall.transform.localPosition.y, 0);
		rightWall.transform.localPosition = new Vector3(rightBorder + 1.0f, rightWall.transform.localPosition.y, 0);
	}
}
