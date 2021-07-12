using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject Player;
    public GameObject ArrowPrefab;
    public Transform NockPoint;

    [Header("Arrow")]
    public float ArrowSpeed;
    Rigidbody2D bowBody;
    // Start is called before the first frame update
    void Start()
    {
        bowBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Right_Joystick_X");
        float yInput = Input.GetAxis("Right_Joystick_Y");

        if (xInput > 0)
        {
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan(yInput / xInput) * Mathf.Rad2Deg) - 90));
        }

        if (xInput < 0)
        {
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan(yInput / xInput) * Mathf.Rad2Deg) + 90));
        }


        //Lerp the rotation towards an angle
        //Si x = 1 mais que y = 0, langle = 90 
        //print(Mathf.Atan(yInput / xInput) * Mathf.Rad2Deg);

        if (Input.GetButtonDown("RB"))
        {
            print("RB on button down !");
            PrepareArrow();
        }

        if (Input.GetButtonUp("RB"))
        {
            print("RB on button up !");
            ShootArrow();
        }

    }

    GameObject arrowClone;

    //On tire la flèche !
    void ShootArrow()
    {
        arrowClone.transform.parent = null;
        arrowClone.GetComponent<Rigidbody2D>().isKinematic = false;
        arrowClone.GetComponent<Rigidbody2D>().velocity = arrowClone.transform.up * ArrowSpeed;
    }

    //On prépare la flèche
    void PrepareArrow()
    {
       arrowClone = Instantiate(ArrowPrefab, NockPoint);
    }
}
