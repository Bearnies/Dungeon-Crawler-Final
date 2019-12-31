using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("You drank a potion !");
        Destroy(gameObject);
    }

    public void Consume(CharactersStats stats)
    {
        Debug.Log("You drank a potion. Nice !");
    }
}
