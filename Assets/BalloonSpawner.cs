using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [Header("Balloons Spawn Settings")]
    public GameObject balloonObject;
    [Range(1, 100)] public int minBalloonSpawn = 10;
    [Range(1, 100)] public int maxBalloonSpawn = 20;
    [Range(-.5f, .001f)] public float minBalloonGravity = -.1f;
    [Range(-.5f, .001f)] public float maxBalloonGravity = -.01f;
    [Range(0f, 20f)] public float minDelayBetweenSpawn = .5f;
    [Range(0f, 20f)] public float maxDelayBetweenSpawn = 3f;
    [Range(1, 20)] public float balloonLifeSpawn = 5f;

    [Header("Map Bounds")]
    public float leftBound = -8.6f;
    public float rightBound = 11.35f;
    public float topBound = 9.7f;
    public float bottomBound = -4.11f;

    private int numOfBalloons;

    private void Awake()
    {
        if (maxBalloonSpawn < minBalloonSpawn)
        {
            throw new System.Exception("maxBalloonSpawn cannot be less than minBalloonSpawn");
        } 
        else if (maxBalloonGravity < minBalloonGravity)
        {
            throw new System.Exception("maxBalloonGravity cannot be less than minBalloonGravity");
        }

        numOfBalloons = Random.Range(minBalloonSpawn, maxBalloonSpawn + 1);
        Debug.Log("numBallons " + numOfBalloons);

    }

    void Start()
    {

        float lastSpawnTime = 0f;

        for (int i = 0; i < numOfBalloons; i++)
        {

            float waitSeconds = Random.Range(lastSpawnTime + minDelayBetweenSpawn, lastSpawnTime + maxDelayBetweenSpawn);

            StartCoroutine(SpawnBalloon(balloonObject, CalculateRandomPosition(), Quaternion.identity, waitSeconds));

            lastSpawnTime += waitSeconds;
        }
    }

    Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(leftBound, rightBound);
        float y = bottomBound;

        return new Vector3(x, y, 0);
    }

    IEnumerator SpawnBalloon(GameObject balloonObject, Vector3 pos, Quaternion location, float waitSeconds)
    {

        yield return new WaitForSeconds(waitSeconds);

        GameObject clone;
        Balloon balloon;

        float gravityScale = Random.Range(minBalloonGravity, maxBalloonGravity);
        Debug.Log("gravityScale: " + gravityScale);

        balloon = balloonObject.GetComponent<Balloon>();
        balloon.balloonColor = (Balloon.BalloonColors) Random.Range(0,5);
        balloon.gravityScale = gravityScale;

        clone = Instantiate(balloonObject, pos, location);

        /*balloon = clone.GetComponent<Balloon>();
        Debug.Log(balloon.gravityScale);
        balloon.balloonColor = Balloon.BalloonColors.Yellow;*/

    }
}
