using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float spawnRate = 2f;

    private List<GameObject> obstacles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroy();
    }

    private void Move()
    {
        Vector3 moveDirection = endPoint.transform.position - startPoint.transform.position;
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
        }
    }

    private void Destroy()
    {
        foreach (GameObject obstacle in obstacles.ToList())
        {
            float distance = Vector3.Distance(obstacle.transform.position, endPoint.transform.position);
            if (distance <= 0.1f)
            {
                Destroy(obstacle);
                obstacles.Remove(obstacle);
            }
        }
    }

    private void SpawnObstacle()
    {
        GameObject createdObstacle = Instantiate(obstacle, startPoint.transform.position, obstacle.transform.rotation);
        obstacles.Add(createdObstacle);
    }
}
