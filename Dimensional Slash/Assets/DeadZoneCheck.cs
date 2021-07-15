using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneCheck : MonoBehaviour
{
    CameraController camCon;
    // Start is called before the first frame update
    void Start()
    {
        camCon = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camCon.playerIsInDeadZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camCon.playerIsInDeadZone = false;
        }
    }
}
