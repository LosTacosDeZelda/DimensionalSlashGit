using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float DelayInSeconds;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfter(DelayInSeconds));
    }
 
    IEnumerator DestroyAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
