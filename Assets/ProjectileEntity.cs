using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEntity : MonoBehaviour
{
    private float mDirection = 0f;
    [SerializeField] private float mSpeed = 10f;
    private Rigidbody2D rigidbody;
    private int maxBounce = 5;
    private int currentBounce = 0;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(mDirection * mSpeed * Time.deltaTime, rigidbody.velocity.y);
    }
    public void initializeProjectile(float direction)
    {
        mDirection = direction;

        print("direction: " + mDirection);
        print("Speed: " + mSpeed);

    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentBounce += 1;
        if(currentBounce >= maxBounce)
        {
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
