using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallListSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls;
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private Slider spawnSlider;

    private GameManager gameManager;

    private float xSpawnRange;
    private float ySpawnRange;

    private float xSpawnPosition;
    private float ySpawnPosition;
    private float zSpawnPosition = 0.0f;
    private Vector3 spawnPosition;

    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        BoxCollider area = spawnArea.GetComponent<BoxCollider>();

        xSpawnRange = area.size.x / 2;
        ySpawnRange = area.size.y / 2;

        StartCoroutine(SpawnBall());
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = spawnSlider.value;
    }

    private Vector3 RandomSpawnPosition()
    {
        xSpawnPosition = spawnArea.transform.position.x + Random.Range(-xSpawnRange, xSpawnRange);
        ySpawnPosition = spawnArea.transform.position.y + Random.Range(-ySpawnRange, ySpawnRange);

        return new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition);
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int ballIndex = Random.Range(0, balls.Count);

            spawnPosition = RandomSpawnPosition();

            if (gameManager.isGameActive)
            {
                Instantiate(balls[ballIndex], spawnPosition, balls[ballIndex].transform.rotation);
            }
        }
    }
}
