using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Les boss seront essentiellement des state machines : ils auront tous plusieurs actions et attaques
public abstract class BossController : EntityController
{
    protected GameObject player;
    protected Rigidbody2D bossRb;
    protected Animator bossAnim;
    protected Vector3 playerDirection;
    protected float distBtwBossAndPlayer;
    int attackIndex;
    int lastAttackIndex;
    //float distBtwBossAndClaw;
    //float distBtwPlayerAndClaw;

    protected bool attackFinished = false;
   
    public int[] AttackDamageValues;

    [Header("General")]
    public int InitialHitpoints;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossRb = GetComponent<Rigidbody2D>();
        bossAnim = GetComponentInChildren<Animator>();

        SetHealthPoints(InitialHitpoints);
    }

    //Boss se prend du dommage du joueur
    //et donne du damage aussi.

    protected virtual void Update()
    {
        playerDirection = player.transform.position - transform.position;

        distBtwBossAndPlayer = Vector2.Distance(transform.position, player.transform.position);
    }

    protected IEnumerator AttackChooser()
    {
        //Reset attackFinished back to false
        attackFinished = false;

        attackIndex = Mathf.RoundToInt(UnityEngine.Random.Range(0, 3));

        //Il peut faire une attaque 2 fois de suite max
        /*while (attackIndex == lastAttackIndex || (GetHealthPoints() > InitialHitpoints / 2 && attackIndex == 2))
        {
            attackIndex = Mathf.RoundToInt(UnityEngine.Random.Range(0, 3));
        }

        lastAttackIndex = attackIndex;*/

        /*if (GetHealthPoints() > InitialHitpoints / 2 && attackIndex == 2)
        {

        }*/

        Attack(attackIndex);

        yield return new WaitUntil(() => attackFinished);

        StartCoroutine(AttackChooser());
    }

    public override void Attack(int chosenAttack)
    {
        //Set attack damage to the chosen attack damage
        SetAttackDamage(AttackDamageValues[chosenAttack]);

        switch (chosenAttack)
        {
            case 0:
                StartCoroutine(BossAttack1());
                break;
            case 1:
                StartCoroutine(BossAttack2());
                break;
            case 2:
                StartCoroutine(SpecialAttack());
                break;
        }
    }

    public override void OnAttackReceived(int receivedDmg)
    {
        print(GetHealthPoints() - receivedDmg);
        //Do the hurt sequence : substract health, flash the boss sprite
        SetHealthPoints(GetHealthPoints() - receivedDmg);
    }

    public abstract IEnumerator BossAttack1();
    public abstract IEnumerator BossAttack2();
    public abstract IEnumerator SpecialAttack();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Tell the player he's been hit !
            collision.GetComponent<PlayerController>().OnAttackReceived(attackDmg);
        }
    }



}
