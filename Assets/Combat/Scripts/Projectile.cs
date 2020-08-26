using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Actor
{
    public float ProjectileSpeed = 10;
    public float ProjectileLifetime = 5;
    public float ProjectileDamage = 10;

    void Start()
    {
        // Move it... 
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.forward * ProjectileSpeed;

        // Set it's lifetime
        Destroy(gameObject, ProjectileLifetime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive)
        {
            // Using Is Active to determine if we're done with gameplay
            return;
        }
        Actor otherActor = other.gameObject.GetComponentInParent<Actor>();
        // if what we hit isn't an Actor, then this will result with a null result

        // See if what we hit is an actor
        // 'if (otherActor)' is equal to 'if (otherActor != null)' 
        // Unity wrote an overload for us. 
        if (otherActor)
        {
            // Since We hit an actor, we can call take damage on it. 
            otherActor.TakeDamage(ProjectileDamage);

            // Property of the Actor Class
            // This will prevent doing multiple damage if we hit multiple colliders on an object. 
            IsActive = false;
        }

        Destroy(gameObject);

        /// The rest of the code in this method 
        /// is here to demostrate IS and AS keywords. 

        // keyword IS
        // Syntax: <expression> is <type>
        // Expression will be variable or an object reference 
        // result: A boolean operation
        if (otherActor is SpecialWall)
        {
            Debug.Log("IS: Special Wall Actor");
        }

        if (otherActor is Player)
        {
            Debug.Log("IS: Player Actor");
        }

        // keyword AS
        // Syntax: <expression> as <type>
        // Expression will be variable or an object reference 
        // result: if variable can be cast as type, then returns the cast, 
        // otherwise, will return null 
        Projectile p = otherActor as Projectile;

        // There's inherited code from unity that makes this if (p != null)
        if (p)
        {
            Debug.Log("AS: Projectile Actor");
        }
        else
        {
            Debug.Log("AS: Wasn't a Projectile Actor");
        }

    }

    // If a projectile hits another projectile, it will do damage to the other and remove it. 
    // If we had an explode method, we'd call it here as well.

    protected override bool ProcessDamage(float amount)
    {
        // making a call to the parent's version of the method. 
        base.ProcessDamage(amount); 
        Destroy(gameObject); 

        return false;
    }
}
