using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Health 
{
    int mHealth;
    int mHealthMax;

    void Start()
    {
        
    }
    private void SetHealth(int newHealth)
    {
        mHealth = newHealth;
        if(mHealth > mHealthMax)
        {
            mHealth = mHealthMax;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
