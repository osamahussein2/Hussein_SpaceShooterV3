using System.Collections;
using System.Collections.Generic;
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
        float rotationAngle = Mathf.Atan2(target.right.y, target.right.x) * Mathf.Rad2Deg;

        if (Vector2.Distance(transform.position, target.position) <= radius)
        {
            transform.Rotate(0, 0, rotationAngle * speed * Time.deltaTime);
        }
    }
}
