using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DontDestroy : MonoBehaviour
{
    // Assigned to gameobject that runs asynchronous calls so that it doesn't get destroyed on scene change.
    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }
    // Functionality of Quit button 
    public void Quitbtn()
    {
        Application.Quit();
    }
}
