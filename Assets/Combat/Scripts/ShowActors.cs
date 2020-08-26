using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowActors : MonoBehaviour
{
    public Actor[] ActorList;
    public TextMeshProUGUI ScreenList; 
    void Start()
    {
        UpdateActorList(); 
    }

    public void UpdateActorList()
    {
        ActorList = GameObject.FindObjectsOfType<Actor>();
        // this will find all instances of Actor
        // This includes scripts that are children of Actor
        string output = "Actors:"; 
        foreach (Actor a in ActorList)
        {
            output = output + "\n" + a.gameObject.name; 
        }
        ScreenList.text = output; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateActorList(); 
        }
    }
}
