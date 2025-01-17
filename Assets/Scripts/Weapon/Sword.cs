﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStats> Stats { get; set; }
    //private Animator animator;
    public CharactersStats charactersStats { get; set; }
    public int CurrentDamage { get; set ; }

    public bool InCombat { get; private set; }

    public AudioClip audioClip;
    public AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        InCombat = false;

        gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    public void PerformAttack(int damage)
    {
        //Debug.Log("Sword Attack !");
        InCombat = true;
        CurrentDamage = damage;
        //animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        //Debug.Log("Special Attack !");
        //animator.SetTrigger("Special_Attack");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            audioSource.PlayOneShot(audioClip);
            collider.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
}
