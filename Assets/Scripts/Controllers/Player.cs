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

    // Update is called once per frame
    void Update()
    {
        EnemyRadar(1.5f, 5);
        SpawnPowerups(2.0f, 4);
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

        float points = 360f / circlePoints;

        for (int i = 0; i < circlePoints; i++)
        {
            // Iterate through at the current point
            float firstAngleInRadians = points * i * Mathf.Deg2Rad;

            float firstPointX = Mathf.Cos(firstAngleInRadians);
            float firstPointY = Mathf.Sin(firstAngleInRadians);

            Vector3 firstPointResultant = new Vector3(firstPointX, firstPointY, 0.0f) * radius;

            // Iterate to the next point
            float angleInRadians = points * (i + 1) * Mathf.Deg2Rad;

            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);

            Vector3 resultant = new Vector3(x, y, 0) * radius;

            Debug.DrawLine(transform.position + firstPointResultant, transform.position + resultant, detectionColor);
        }
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float points = 360f / numberOfPowerups;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            // Iterate through all the points
            float angleInRadians = points * i * Mathf.Deg2Rad;

            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);

            Vector3 resultant = new Vector3(x, y, 0) * radius;

            powerupPrefab.transform.position = transform.position + resultant;

            Instantiate(powerupPrefab);
        }

    }
}
