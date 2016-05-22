using UnityEngine;
using System.Collections;

public class DrawWalls : MonoBehaviour {
    private Transform leftWall;
    private Transform rightWall;

    void Start() {
        leftWall = transform.Find("LeftWall").gameObject.transform;
        rightWall = transform.Find("RightWall").gameObject.transform;
    }

	void Update() {
        // Get camera borders
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        float dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = transform.InverseTransformPoint(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist))).x;
        float rightBorder = transform.InverseTransformPoint(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist))).x;

        // Dynamically set the walls' positions
        leftWall.localPosition = new Vector3(leftBorder - 0.5f, leftWall.localPosition.y, leftWall.localPosition.z);
        rightWall.localPosition = new Vector3(rightBorder + 0.5f, rightWall.localPosition.y, rightWall.localPosition.z);

        // NJD TODO: Consider altering the ceiling's scale (currently hard coded to 50 units long, which should work for every screen size.
    }
}
