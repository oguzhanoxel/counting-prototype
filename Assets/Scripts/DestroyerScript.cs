using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private float destroyTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Destroy(gameObject);
    }
}
