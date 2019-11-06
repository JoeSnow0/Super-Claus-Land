using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    private Vector2 mDirection;
    void Update()
    {
        mRigidbody.MovePosition(mDirection);

    }
}
