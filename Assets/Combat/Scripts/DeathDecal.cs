using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We insantiate an instance, and it gets removed after lifetime seconds. 
// The object has a cube that is a child mostly because I didn't want play around with the rotation in the script. 
public class DeathDecal : MonoBehaviour
{
    // In Unreal, this would have been an Actor 
    // Since this isn't gameplay related, and just decorative 
    // We can get away with it not being an Actor...
    // Anything more complicated, I would have considered inheritance of Actor

   
    public float LifeTime = 2.5f; // time in seconds. 
    void Start()
    {
        Destroy(gameObject, LifeTime); 
    }
}
