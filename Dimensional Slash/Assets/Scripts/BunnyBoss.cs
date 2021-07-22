using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBoss : BossController
{
    
    List<Vector2> ClawInitialPositions = new List<Vector2>();

    public GameObject[] ClawHitboxes;

    [Header("Claw Swipe Attack")]
    [Range(1,10)]public float LungeDistance;
    [Range(1, 50)] public float FrenesyFactor;
    [Range(2, 20)] public int NumOfSwipes;

    [Header("Ground Smash Attack")]
    public GameObject HitboxPrefab;
    [Range(1, 6)] public float SmashRadius;
    [Range(0,1)] public float hitBoxDistFromBoss;
    public int FollowSpeed;

    [Header("Teleport Special Attack")]
    public int TeleportSpeed;
    public float TeleportDelay;
    //Counter window
    public float AnticipationDelay;

    bool canFollowPlayer = false;
    bool stopBoss = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        for (int i = 0; i < ClawHitboxes.Length; i++)
        {
            ClawInitialPositions.Add(ClawHitboxes[i].transform.localPosition);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AttackChooser());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(SpecialAttack());
        }
    }

    private void FixedUpdate()
    {
        if (canFollowPlayer)
        {
            bossRb.velocity = playerDirection.normalized * FollowSpeed;
        }

        if (distBtwBossAndPlayer < 2)
        {
            bossRb.velocity = Vector2.zero;
        }
     
    }

    //Claw Swipe
    public override IEnumerator BossAttack1()
    {

        print("Doing Claw Swipe. Damage : " + attackDmg);
        //print(playerDirection);

        for (int i = 0; i < NumOfSwipes; i++)
        {
            if (distBtwBossAndPlayer > 3)
            {
                bossRb.velocity = (playerDirection.normalized) * LungeDistance;

                if (i % 2 == 0)
                {
                    //Swipe with right claw !
                    ClawHitboxes[0].transform.position += playerDirection.normalized;

                }
                else
                {
                    //Swipe with left claw !
                    ClawHitboxes[1].transform.position += playerDirection.normalized;
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    //Swipe with right claw !
                    ClawHitboxes[0].transform.position = transform.position + (playerDirection.normalized * UnityEngine.Random.Range(2f, 10f));
                }
                else
                {
                    ClawHitboxes[1].transform.position = transform.position + (playerDirection.normalized * UnityEngine.Random.Range(2f, 10f));

                }

            }

            yield return new WaitForSeconds(1 / FrenesyFactor);
            bossRb.velocity = Vector2.zero;
            yield return new WaitForSeconds(1 / FrenesyFactor);
        }

        //Reset the boss to a neutral state, attack is finished
        for (int i = 0; i < ClawHitboxes.Length; i++)
        {
            ClawHitboxes[i].transform.localPosition = ClawInitialPositions[i];
        }

        bossRb.velocity = Vector2.zero;
        attackFinished = true;

    }

    //Ground Smash
    public override IEnumerator BossAttack2()
    {
        print("Doing Ground Smash. Damage : " + attackDmg);

        //Slowly follow player !
        canFollowPlayer = true;
        bossAnim.SetBool("PreparingSmash", true);
        yield return new WaitForSeconds(2f);

        //Boss Smashes Ground, hitbox appears and boss stops moving
        canFollowPlayer = false;
        bossAnim.SetBool("PreparingSmash", false);

        GameObject hitboxClone = Instantiate(HitboxPrefab,transform.position + (playerDirection * hitBoxDistFromBoss), Quaternion.identity);
        hitboxClone.transform.localScale = Vector3.one * (SmashRadius * 2);

        bossRb.velocity = Vector2.zero;

        yield return new WaitForSeconds(2f);
        //Physics2D.OverlapCircle()
        //Reset the boss to a neutral state, attack is finished
        
        attackFinished = true;
    }


    //Teleport
    public override IEnumerator SpecialAttack()
    {
        print("Doing Special Attack. Damage : " + attackDmg);
        bossRb.velocity = playerDirection.normalized * TeleportSpeed;
        yield return new WaitForSeconds(TeleportDelay);
        ClawHitboxes[0].transform.position = player.transform.position;
        ClawHitboxes[1].transform.position = player.transform.position;
        bossRb.velocity = Vector2.zero;
        yield return new WaitForSeconds(AnticipationDelay);

        //Reset the boss to a neutral state, attack is finished
        for (int i = 0; i < ClawHitboxes.Length; i++)
        {
            ClawHitboxes[i].transform.localPosition = ClawInitialPositions[i];
        }

        attackFinished = true;
    }
}
