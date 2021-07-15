using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Les boss seront essentiellement des state machines : ils auront tous plusieurs actions et attaques
public class BossController : EntityController
{
    public class Attacks
    {
        public int DamageDealt;
    }

    

    public override void Attack(int chosenAttack)
    {

    }

    public override void OnAttackReceived(int receivedDmg)
    {

    }
}
