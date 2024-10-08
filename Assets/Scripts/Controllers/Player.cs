using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;

    private Color detectionColor;

    int currentAngleIndex = 0;

    // Update is called once per frame
    void Update()
    {
        EnemyRadar(1.5f, 5);
        SpawnPowerups(2.0f, 3);
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
            points.Add(360f / i);

            // Create the first circle point
            float firstAngleInRadians = points[0] * Mathf.Deg2Rad;

            float firstPointX = Mathf.Cos(firstAngleInRadians);
            float firstPointY = Mathf.Sin(firstAngleInRadians);

            Vector3 firstPointResultant = new Vector3(firstPointX, firstPointY, 0.0f) * radius;

            // Create the the rest of the circle points
            float angleInRadians = points[i] * Mathf.Deg2Rad;

            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);

            Vector3 resultant = new Vector3(x, y, 0) * radius;

            Vector3 direction = resultant + (firstPointResultant - resultant);

            Debug.DrawLine(firstPointResultant + resultant, direction, detectionColor);
        }
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        List<float> points = new List<float>();

        for (int i = 0; i < numberOfPowerups; i++)
        {
            points.Add(360f / i);
        }

        currentAngleIndex = (currentAngleIndex + 1) % points.Count;

        // Create the the rest of the circle points
        float angleInRadians = points[currentAngleIndex] * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);

        Vector3 resultant = new Vector3(x, y, 0) * radius;

        Instantiate(powerupPrefab, transform);

    }
}
