using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEntity : MonoBehaviour
{
    private float mDirection = 0f;
    [SerializeField] private float mSpeed = 500f;
    private Rigidbody2D rigidbody;
    private int maxBounce = 5;
    private int currentBounce = 0;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void initializeProjectile(float direction, float speed)
    {
        mDirection = direction;
        mSpeed = mSpeed + speed;

        print("direction: " + mDirection);
        print("Speed: " + mSpeed);

    }
    private void Update()
    {
        rigidbody.velocity = new Vector2(mDirection * mSpeed * Time.deltaTime, rigidbody.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentBounce += 1;
        if(currentBounce >= maxBounce)
        {
            Destroy(gameObject);
        }
    }
}
