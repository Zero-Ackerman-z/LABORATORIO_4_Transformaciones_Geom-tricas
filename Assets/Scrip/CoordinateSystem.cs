using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystem : MonoBehaviour
{
    public float size = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + transform.right * -size / 2f, transform.position + transform.right * size / 2f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + transform.up * -size / 2f, transform.position + transform.up * size / 2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + transform.forward * -size / 2f, transform.position + transform.forward * size / 2f);
    }
}
