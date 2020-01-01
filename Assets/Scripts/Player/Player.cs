using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharactersStats charactersStats;

    // Start is called before the first frame update
    void Start()
    {
        charactersStats = new CharactersStats(10, 10, 10);
    }

}
