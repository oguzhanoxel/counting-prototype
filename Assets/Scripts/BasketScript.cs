using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BasketScript : MonoBehaviour
{
    private GameManager gameManager;

    private float destroyTime = 3.0f;

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
        IEnumerator waitAndDestroy = WaitAndDestroy(other.gameObject);
        StartCoroutine(waitAndDestroy);
    }

    private IEnumerator WaitAndDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(destroyTime);
        
        if (gameObject != null)
        {
            if ("Green" == gameObject.tag)
            {
                gameManager.IncreaseGreenCounter();
            } else if ("Purple" == gameObject.tag)
            {
                gameManager.IncreasePurpleCounter();
            } else if ("Red" == gameObject.tag)
            {
                gameManager.IncreaseRedCounter();
            }
            Destroy(gameObject);
        }
    }
}
