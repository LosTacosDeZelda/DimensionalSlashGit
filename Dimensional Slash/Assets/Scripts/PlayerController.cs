using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    public GameManager gameManager;

    PossibleDimensions currentDimension;
    enum PossibleDimensions
    {
        Day,
        Night
    }

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    public Camera myCam;
    [Space]
    [Header("Movement Settings")]
    [SerializeField]
    Vector2 inputAxises;
    [SerializeField]
    [Range(0, 0.05f)]
    float inputRampSpeed = 0.015f;
    [SerializeField]
    Rigidbody2D myRb;

    [SerializeField]
    [Range(0, 1.5f)]
    float accelSpeed;
    [SerializeField]
    [Range(0, 1.5f)]
    float dampSpeed = 0.005f;
    [SerializeField]
    float idleTimer = 0;
    //Dash
    float dashDistance;
    float dashSpeed;

    void GetInputs()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        float absX = Mathf.Abs(xInput);
        float absY = Mathf.Abs(yInput);

        //Debug.Log($"Absolute X: {absX}, Absolute Y: {absY}");


        if (absX > 0 && inputAxises.x < 1.0f) inputAxises.x += xInput * inputRampSpeed;

        if (absY > 0 && inputAxises.y < 1.0f) inputAxises.y += yInput * inputRampSpeed;

        if (absX == 0) inputAxises.x = 0;
        if (absY == 0) inputAxises.y = 0;

        inputAxises.x = Mathf.Clamp(inputAxises.x, -1, 1);
        inputAxises.y = Mathf.Clamp(inputAxises.y, -1, 1);

        MovementManager(inputAxises.x, inputAxises.y);
    }
    void MovementManager(float xInput, float zInput)
    {
        float xVelocity = myRb.velocity.x;
        xVelocity += xInput * accelSpeed;

        float zVelocity = myRb.velocity.y;
        zVelocity += zInput * accelSpeed;
        //Debug.Log("xVelocity before : " + xVelocity);

        if (Mathf.Abs(xInput) < 0.01f) xVelocity *= Mathf.Pow(1f - dampSpeed, Time.deltaTime * 10f);
        if (Mathf.Abs(zInput) < 0.01f) zVelocity *= Mathf.Pow(1f - dampSpeed, Time.deltaTime * 10f);

        if (Mathf.Abs(xVelocity) > moveSpeed && xInput != 0) xVelocity = (xVelocity > 0) ? moveSpeed : -moveSpeed;
        if (Mathf.Abs(zVelocity) > moveSpeed && zInput != 0) zVelocity = (zVelocity > 0) ? moveSpeed : -moveSpeed;

        Vector2 movement = new Vector2(xVelocity, zVelocity);
        //Debug.Log(movement);

        myRb.velocity = movement;

        Vector2 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - myRb.position;
        float newAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        myRb.rotation = newAngle;

    }


    //Called when the player slashes the screen with the special katana and changes dimensions
    void SwitchDimension()
    {

        gameManager.ChangeDimension(GameManager._Dimensions.Day);
    }

    public override void Attack(int chosenAttack)
    {

    }

    public override void OnAttackReceived(int receivedDmg)
    {

    }

}
