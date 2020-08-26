using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Which player? Assigned in Editor
    public bool IsPlayer1 = true; // This is only a 2 player game. 

    // Movement - can be overriden in Editor as needed
    public float MoveSpeed = 5;
    public float RotationRate = 90;

    // Assigned in Editor
    public GameObject ProjectileSpawn; // Where to Spawn from on the model
    public GameObject ProjectilePrefab; // Prefab to spawn, when firing
    public GameObject DeathPrefab; // Prefab to spawn, on death

    // Used for Respawning
    Vector3 StartingLocation;
    Quaternion StartingRotation; 
    public float StartingHealth = 50;
   
    // Input
    float Horizontal = 0;
    float Vertical = 0;
    bool Fire1 = false; 

    // Rigid Body
    Rigidbody rb; 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartingLocation = gameObject.transform.position;
        StartingRotation = gameObject.transform.rotation;
        Health = StartingHealth; 
    }

    
    void Update()
    {
        GetInput();

        Move(Vertical);
        Turn(Horizontal);
        if (Fire1)
        {
            FireProjectile(); 
        }

    }
      
    public void GetInput()
    {
        if (IsPlayer1)
        {
            GetInputPlayer1();
        }
        else
        {
            GetInputPlayer2();
        }
    }

    public void GetInputPlayer1()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Fire1 = Input.GetButtonDown("Fire1");

    }

    public void GetInputPlayer2()
    {
        Horizontal = Input.GetAxis("HorizontalP2");
        Vertical = Input.GetAxis("VerticalP2");
        Fire1 = Input.GetButtonDown("Fire1P2");
    }

    void Move(float value)
    {
        rb.velocity = value * gameObject.transform.forward * MoveSpeed; 
    }

    void Turn(float value)
    {
        gameObject.transform.Rotate(Vector3.up * value * RotationRate * Time.deltaTime); 
        
    }

    void FireProjectile()
    {
        Instantiate(ProjectilePrefab, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation); 
    }

    public void Respawn()
    {
        gameObject.transform.position = StartingLocation;
        gameObject.transform.rotation = StartingRotation;
        Health = StartingHealth;
    }

    public void DropDeathPrefab()
    {
        Instantiate(DeathPrefab, gameObject.transform.position, Quaternion.identity); 
    }

    protected override bool ProcessDamage(float amount)
    {
        Health -= amount; 
        Debug.Log("Player " + gameObject.name + " got hit for " + amount + " damage and now at " + Health + " health");
        if (Health <= 0)
        {
            DropDeathPrefab();
            Respawn();
            CombatManager.reference.AddScore(IsPlayer1, 1); 
        }
        return false;
    }

}
