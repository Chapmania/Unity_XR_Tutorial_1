using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingCar : MonoBehaviour
{
    float timer = 0.0f;
    int radius = 7;
    public float carSpeed;
    void Update()
    {
        timer += Time.deltaTime;
        float x = Mathf.Cos(carSpeed/10 * timer);
        float z = Mathf.Sin(carSpeed/10 * timer);
        transform.position = new Vector3(x * radius, 0f, z * radius);
        transform.forward = Vector3.Cross(transform.position, transform.up);
    }
}
