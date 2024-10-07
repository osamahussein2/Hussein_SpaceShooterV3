using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    private Color detectionColor;

    // Update is called once per frame
    void Update()
    {
        EnemyRadar(1.5f, 5);
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        // Set the line color to red if the player is close to the enemy from a specific distance from the radius
        if (Vector2.Distance(transform.position, enemyTransform.position) <= radius)
        {
            detectionColor = Color.red;
        }

        // Else set the line color to green
        else
        {
            detectionColor = Color.green;
        }

        List<float> points = new List<float>();

        for (int i = 0; i < circlePoints; i++)
        {
            points.Add(Random.Range(0, 360f));

            // Create the first circle point
            float firstAngleInRadians = points[0];

            float firstPointX = Mathf.Cos(firstAngleInRadians);
            float firstPointY = Mathf.Sin(firstAngleInRadians);

            Vector3 firstPointResultant = new Vector3(firstPointX, firstPointY, 0.0f) * radius;

            // Create the the rest of the circle points
            float angleInRadians = points[i];

            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);

            Vector3 resultant = new Vector3(x, y, 0) * radius;

            Debug.DrawLine(transform.position + firstPointResultant, transform.position + resultant, detectionColor);
        }
    }
    
}
