using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLayerSwapper : MonoBehaviour
{
    GameObject CloseObject;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (CloseObject != null)
        {
            if (transform.position.y > CloseObject.transform.position.y)
            {
                if (CloseObject.GetComponent<SpriteRenderer>() == null)
                {
                    sr.sortingOrder = CloseObject.GetComponentInChildren<SpriteRenderer>().sortingOrder - 2;
                }
                else
                {
                    sr.sortingOrder = CloseObject.GetComponent<SpriteRenderer>().sortingOrder - 2;
                }
            }
            else if(transform.position.y < CloseObject.transform.position.y)
            {
                if (CloseObject.GetComponent<SpriteRenderer>() == null)
                {
                    sr.sortingOrder = CloseObject.GetComponentInChildren<SpriteRenderer>().sortingOrder + 2;
                }
                else
                {
                    sr.sortingOrder = CloseObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CloseObject = collision.gameObject;
    }
}
