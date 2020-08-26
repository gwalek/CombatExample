using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWall : Actor
{
    // This is just another example of an Actor 
    // This will allow us to see an interaction between it and the projectile. 
    protected override bool ProcessDamage(float amount)
    {
        // If I had sounds, I would play one here. 
        Debug.Log("Wall of " + gameObject.name + " got hit for " + amount + " damage.");
        return false;
    }
}
