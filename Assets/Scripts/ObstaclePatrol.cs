using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePatrol : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    [SerializeField] private float speed = 3.0f;

    private bool movingToEnd = true;


    // Start is called before the first frame update
    void Start()
    {
        obstacle.transform.position = startPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float distanceEndPoint = Vector3.Distance(obstacle.transform.position, endPoint.transform.position);
        float distanceStartPoint = Vector3.Distance(obstacle.transform.position, startPoint.transform.position);

        Vector3 moveDirection = movingToEnd ? endPoint.transform.position - startPoint.transform.position : startPoint.transform.position - endPoint.transform.position;
        obstacle.transform.Translate(moveDirection.normalized * speed * Time.deltaTime);

        if (movingToEnd ? distanceEndPoint <= 0.1f : distanceStartPoint <= 0.1f)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
