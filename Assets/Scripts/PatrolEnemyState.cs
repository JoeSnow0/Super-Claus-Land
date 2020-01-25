using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyState : EnemyState
{
    Vector2 mDirection = Vector2.left;
    EnemyEntity myStats;
    bool isMoving;
    public void EnterState(EnemyEntity stats)
    {
        myStats = stats;
    }

    public void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        Move();
    }

    public void OnCollision2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player");
        {

        }
        if (otherCollider.gameObject.tag == "Enemy") ;
        {

        }
        InvertDirection();
    }
    void Move()
    {

    }
    void InvertDirection()
    {
       
    }

    
}
