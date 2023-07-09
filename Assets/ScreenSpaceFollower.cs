using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceFollower : MonoBehaviour
{
    public GameObject parent;
    public Camera c;

    void FixedUpdate() {
        Vector3 worldPos = c.ScreenToWorldPoint(parent.transform.position);
        gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        gameObject.transform.rotation = parent.transform.rotation;
    }
}
