using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Les boss seront essentiellement des state machines : ils auront tous plusieurs actions et attaques
public class BossController : EntityController
{
    GameObject player;
    Rigidbody2D bossRb;
    Vector3 playerDirection;
    float distBtwBossAndPlayer;
    float distBtwBossAndClaw;
    float distBtwPlayerAndClaw;

    List<Vector2> ClawInitialPositions = new List<Vector2>();

    public GameObject[] ClawHitboxes;
    public float LungeDistance;
    public float FrenesyFactor;

    public class BossAttack
    {
        public int DamageDealt;
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossRb = GetComponent<Rigidbody2D>();

        foreach (var claw in ClawHitboxes)
        {

        }

        for (int i = 0; i < ClawHitboxes.Length; i++)
        {
            ClawInitialPositions.Add(ClawHitboxes[i].transform.localPosition);

        }

        InvokeRepeating("AttackChooser", 0f, 5f);
    }
    //Boss se prend du dommage du joueur
    //et donne du damage aussi.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackChooser();
        }

        playerDirection = player.transform.position - transform.position;

        distBtwBossAndPlayer = Vector2.Distance(transform.position, player.transform.position);
        //distBtwBossAndClaw = Vector2()
    }

    void AttackChooser()
    {
        Attack(0);
    }

    public override void Attack(int chosenAttack)
    {
        StartCoroutine(ClawSwipe(12)); 
    }

    public override void OnAttackReceived(int receivedDmg)
    {

    }

    IEnumerator ClawSwipe(int numOfSwipes)
    {
        

        print(playerDirection);
        for (int i = 0; i < numOfSwipes; i++)
        {
            if (distBtwBossAndPlayer > 3)
            {
                bossRb.velocity = (playerDirection.normalized) * LungeDistance;

                if (i % 2 == 0)
                {
                    //Swipe with right claw !
                    ClawHitboxes[0].transform.position += playerDirection.normalized;
                    /*if (Vector2.Distance(ClawHitboxes[0].transform.position, player.transform.position) > distBtwBossAndPlayer)
                    {
                        ClawHitboxes[0].transform.position -= playerDirection.normalized;
                    }
                    else
                    {
                        ClawHitboxes[0].transform.position += playerDirection.normalized;
                    }
                    */


                    // print(i);
                }
                else
                {
                    ClawHitboxes[1].transform.position += playerDirection.normalized;
                    /*if (Vector2.Distance(ClawHitboxes[1].transform.position, player.transform.position) > distBtwBossAndPlayer)
                    {
                        ClawHitboxes[1].transform.position -= playerDirection.normalized;
                    }
                    else
                    {
                        ClawHitboxes[1].transform.position += playerDirection.normalized;
                    }*/

                    //Swipe with left claw !
                    // print(i);
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    //Swipe with right claw !
                    ClawHitboxes[0].transform.position = transform.position + (playerDirection.normalized * UnityEngine.Random.Range(2f, 3f));
                }
                else
                {
                    ClawHitboxes[1].transform.position = transform.position + (playerDirection.normalized * UnityEngine.Random.Range(2f, 3f)); 
          
                }
                
            }
            

            yield return new WaitForSeconds(FrenesyFactor);
            bossRb.velocity = Vector2.zero;
            yield return new WaitForSeconds(FrenesyFactor);
        }

        //Reset the boss to a neutral state
        for (int i = 0; i < ClawHitboxes.Length; i++)
        {
            ClawHitboxes[i].transform.localPosition = ClawInitialPositions[i];
        }
        bossRb.velocity = Vector2.zero;
    }
}
