using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    protected override void Start()
    {
        
    }
    private void FixedUpdate()
    {
        CheckIfGrounded();
        Move();
        Turn();
        Jump();
    }
    protected override void Update()
    {
        UpdateAnimations();
    }
}
