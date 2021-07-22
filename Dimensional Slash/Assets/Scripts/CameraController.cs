using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject player;
    public float CamSpeed;
    
    public Vector2 followOffset;
    Vector2 threshold;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        threshold = calculateThreshold();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;

        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);

        t.x -= followOffset.x;
        t.y -= followOffset.y;

        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

    private void FixedUpdate()
    {
        Vector2 follow = player.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;

        if (Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }

        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }

        float moveSpeed = rb.velocity.magnitude > CamSpeed ? rb.velocity.magnitude : CamSpeed;
        transform.position = Vector3.Lerp(new Vector3(0, transform.position.y, -10), new Vector3(0, newPosition.y, -10), CamSpeed * Time.deltaTime);
        //Vector3.MoveTowards(new Vector3(0, transform.position.y,-10) , new Vector3(0, newPosition.y, -10), moveSpeed * Time.deltaTime);//
    }


}
