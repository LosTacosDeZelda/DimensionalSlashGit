using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    BoxCollider2D deadZones;
    EdgeCollider2D deadZone;
    public bool playerIsInDeadZone = true;
    public float CamSpeed;

    public float movementThreshold = 3;

    Vector3 moveTemp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deadZone = GetComponentInChildren<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        /*else if (yDifference <= -movementThreshold)
        {
            moveTemp = player.transform.position;
            moveTemp.z = -10;
            transform.position = Vector3.Lerp(new Vector3(0, transform.position.y - 3, -10), new Vector3(0, player.transform.position.y, -10), CamSpeed);
        }*/
        
 

        /*if (playerIsInDeadZone == false && Vector2.Distance(player.transform.position,new Vector2(deadZone.bounds.ClosestPoint(player.transform.position).x, deadZone.bounds.ClosestPoint(player.transform.position).y)) > 3)
        {
            print("lerping");
            transform.position = Vector3.Lerp(new Vector3(0, transform.position.y, -10), new Vector3(0, player.transform.position.y, -10), CamSpeed);
        }*/

      

        /*if (deadZone.bounds.Intersects(player.GetComponent<BoxCollider2D>().bounds))
        {
            playerIsInDeadZone = true;
        }
        else
        {
            playerIsInDeadZone = false;
        } */

    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(new Vector3(0, transform.position.y, -10), new Vector3(0, player.transform.position.y, -10), CamSpeed);
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
             playerIsInDeadZone = true;
         }

     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
             playerIsInDeadZone = false;
         }
     }*/


}
