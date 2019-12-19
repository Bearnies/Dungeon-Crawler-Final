using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A Singleton (Only created once)
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Activate when Awake
    void Awake()
    {
        instance = this;
    }

    public GameObject player;
}
