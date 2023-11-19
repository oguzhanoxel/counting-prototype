using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private float destroyTime = 3.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(WaitAndDestroy(other.gameObject));
    }

    private IEnumerator WaitAndDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(destroyTime);

        if (gameObject != null) 
        { 
            Destroy(gameObject);
            gameManager.IncreaseDestroyCounter();
        }
    }
}
