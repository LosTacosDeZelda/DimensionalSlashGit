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
    public int dimensionIndex = 0;
    GameManager._Dimensions currentDimension;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchDimension();
        }
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
        //Incrémente l'index de dimension
        dimensionIndex++;
        
        if (dimensionIndex > 1)
        {
            dimensionIndex = 0;
        }

        currentDimension = (GameManager._Dimensions)dimensionIndex;

        gameManager.ChangeDimension(currentDimension);

    }

    
    public override void Attack(int chosenAttack)
    {

    }

    public override void OnAttackReceived(int receivedDmg)
    {

    }

}
