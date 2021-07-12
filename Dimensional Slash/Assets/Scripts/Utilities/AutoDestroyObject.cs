using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyObject : MonoBehaviour
{
    public int SecondsBeforeDestruction;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTimer(SecondsBeforeDestruction));
    }

    IEnumerator DestroyAfterTimer(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }
}
