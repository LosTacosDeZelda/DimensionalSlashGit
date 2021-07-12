using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{

    public Vector2 playerSpeed;

    public GameManager gameManager;
    Vector2 inputAxises;
    float dashDistance;
    float dashSpeed;
    PossibleDimensions currentDimension;
    enum PossibleDimensions
    {
        Day,
        Night
    }

    Rigidbody2D playerBody;
    
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TopdownMovement();
    }

    void TopdownMovement()
    {
        inputAxises.x = Input.GetAxis("Left_Joystick_X");
        inputAxises.y = Input.GetAxis("Left_Joystick_Y");

        playerBody.velocity =  new Vector2(inputAxises.x * playerSpeed.x, inputAxises.y * playerSpeed.y);
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
