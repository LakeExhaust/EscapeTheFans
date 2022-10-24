using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothing;
    public Vector2 maxBoundary;
    public Vector2 minBoundary;

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
                targetPos.x = Mathf.Clamp(targetPos.x, minBoundary.x, maxBoundary.x);
                transform.position = Vector3.Slerp(transform.position, targetPos, smoothing);
            }
        }
    }
}
