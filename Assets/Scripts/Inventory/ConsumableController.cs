using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    CharactersStats stats;
    Player player;
    public int currentHealth;

    public AudioClip audioClip;
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        stats = GetComponent<Player>().charactersStats;
        player = GetComponent<Player>();

        gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if (item.ItemModifier)
        {
            if ((player.currentHealth + 30) >= 100)
            {
                player.RegainHealth(100 - player.currentHealth);
            }
            else
            {
                player.RegainHealth(30);
            }

            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            if ((player.currentHealth + 30) >= 100)
            {
                player.RegainHealth(100 - player.currentHealth);
            }
            else
            {
                player.RegainHealth(30);
            }

            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
        audioSource.PlayOneShot(audioClip);
    }
}
