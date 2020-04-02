using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigglySphere : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    
    void Start()
    {
        int horizontalLines = 200, verticalLines = 200;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new Vector3[horizontalLines * verticalLines];
        int index = 0;
        for (int m = 0; m < horizontalLines; m++)
        {
            for (int n = 0; n < verticalLines ; n++)
            {
                float x = Mathf.Sin(Mathf.PI * m / horizontalLines) * Mathf.Cos(2 * Mathf.PI * n / verticalLines);
                float y = Mathf.Sin(Mathf.PI * m / horizontalLines) * Mathf.Sin(2 * Mathf.PI * n / verticalLines);
                float z = Mathf.Cos(Mathf.PI * m / horizontalLines);
                Debug.Log(m + " " + n + " "+x + " " + y + " " + z);
                vertices[index++] = new Vector3(x, y, z) ;
            }
        }
        

        int t = 0;
        triangles = new int[(horizontalLines-1) * (verticalLines-1) * 6];
        for(int i =0 ; i< horizontalLines-1; i++)
        {
            for(int j = 0; j< verticalLines-1; j++)
            {
                int r = j + i * horizontalLines;
                triangles[t++] = r;
                triangles[t++] = r + horizontalLines + 1;
                triangles[t++] = r + horizontalLines;
                triangles[t++] = r;
                triangles[t++] = r  + 1;
                triangles[t++] = r + horizontalLines + 1;
            }
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        
        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time) /75;
        }

        mesh.vertices = vertices;
    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(transform.TransformPoint(vertices[i]), 0.05f);
        }
    }
}
