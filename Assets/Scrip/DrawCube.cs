using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawCube : MonoBehaviour
{
    private Vector3 center = Vector3.zero;
    private Vector3 size = Vector3.one;
    public float pointSize = 0.1f;

    // Valores públicos de traslación y escalado
    public Vector3 translation = Vector3.zero;
    public Vector3 scaling = Vector3.one;

    private void OnDrawGizmos()
    {
        // Calcular los puntos del cubo
        Vector3[] cubePoints = CalculateCubePoints();
        // Aplicar traslación 
        for (int i = 0; i < cubePoints.Length; i++)
        {
            cubePoints[i] += center + translation;
        }
        // Aplicar escalado 
        for (int i = 0; i < cubePoints.Length; i++)
        {
            cubePoints[i] = new Vector3(cubePoints[i].x * scaling.x, cubePoints[i].y * scaling.y, cubePoints[i].z * scaling.z);
        }
        DrawCubeLines(cubePoints);
        DrawCubePoints(cubePoints);
    }
    private Vector3[] CalculateCubePoints()
    {
        Vector3[] points = new Vector3[8];
        // Calcular los puntos del cubo
        Vector3 minCorner = -size / 2f;
        Vector3 maxCorner = size / 2f;

        points[0] = new Vector3(minCorner.x, minCorner.y, minCorner.z);
        points[1] = new Vector3(maxCorner.x, minCorner.y, minCorner.z);
        points[2] = new Vector3(maxCorner.x, minCorner.y, maxCorner.z);
        points[3] = new Vector3(minCorner.x, minCorner.y, maxCorner.z);

        points[4] = new Vector3(minCorner.x, maxCorner.y, minCorner.z);
        points[5] = new Vector3(maxCorner.x, maxCorner.y, minCorner.z);
        points[6] = new Vector3(maxCorner.x, maxCorner.y, maxCorner.z);
        points[7] = new Vector3(minCorner.x, maxCorner.y, maxCorner.z);

        return points;
    }
    private void DrawCubeLines(Vector3[] points)
    {
        // líneas horizontales
        Gizmos.DrawLine(points[0], points[1]);
        Gizmos.DrawLine(points[1], points[2]);
        Gizmos.DrawLine(points[2], points[3]);
        Gizmos.DrawLine(points[3], points[0]);
        // líneas verticales
        Gizmos.DrawLine(points[4], points[5]);
        Gizmos.DrawLine(points[5], points[6]);
        Gizmos.DrawLine(points[6], points[7]);
        Gizmos.DrawLine(points[7], points[4]);
        // Conectar las líneas horizontales y verticales
        Gizmos.DrawLine(points[0], points[4]);
        Gizmos.DrawLine(points[1], points[5]);
        Gizmos.DrawLine(points[2], points[6]);
        Gizmos.DrawLine(points[3], points[7]);
    }
    private void DrawCubePoints(Vector3[] points)
    {
        // Dibujar puntos en las esquinas del cubo
        Gizmos.color = Color.blue;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i], pointSize);
        }
    }
}



