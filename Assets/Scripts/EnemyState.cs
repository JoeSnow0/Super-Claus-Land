using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyState
{
    void EnterState(EnemyEntity stats);
    void UpdateState();
    void ExitState();

    void OnCollision2D(Collider2D otherCollider);

}
