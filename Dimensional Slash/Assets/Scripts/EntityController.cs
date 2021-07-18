using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    SpriteController spriteCtrl;
    int healthPoints;
    float moveSpeed;
    int attackID;
    int attackDmg;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

    public void SetHealthPoints(int hp)
    {
        healthPoints = hp;
    }

    public int GetAttackDamage()
    {
        return attackDmg;
    }

    public abstract void Attack(int chosenAttack);
    public abstract void OnAttackReceived(int receivedDmg);

}
