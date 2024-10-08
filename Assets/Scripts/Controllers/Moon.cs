using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(2.0f, 4.0f, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        float angleInRadians = Random.Range(0, 360f) * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);

        transform.position = new Vector3(target.position.x + x, target.position.y + y, 0.0f) * radius;

        float rotationAngle = Mathf.Atan2(target.right.y, target.right.x) * Mathf.Rad2Deg;
        if (rotationAngle < 360.0f)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }

        else
        {
            rotationAngle = -360.0f;
        }
    }
}
