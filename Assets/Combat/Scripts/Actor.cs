using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an concrete class that is being used abstract. 
// This will be inherited in children to do other things. 
public class Actor : MonoBehaviour
{
    // An Actor has Health and can take damage
    // It can also remain in the scene, but not be active in gameplay
    public bool IsActive = true;
    public float Health = 100;


    public bool TakeDamage(float amount)
    {
        // public interface for actors to take damage
        // this is a simplified version that talked about in AGGP 101
        // AGGP 131, the follow on course, looks at Unreal's Version of the function and it's paramerters. 

        return ProcessDamage(amount); 
    }

    // Note the vitrual here... That indicates it can be overriden in children. 
    // The child class will use the word override in their version. 
    protected virtual bool ProcessDamage(float amount)
    {
        // This is intended to be overriden completely in children
        // to handle it's situation.

        // this below is for testing
        Debug.Log(gameObject.name + " got hit for " + amount + " damage.");

        return false;
    }
    

}
