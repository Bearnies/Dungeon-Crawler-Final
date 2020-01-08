using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    public AudioClip audioClip;
    public AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip hitaudioClip;
    public AudioSource hitaudioSource { get { return GetComponent<AudioSource>(); } }
    public ParticleSystem fireballExplosion;

    //void Awake()
    //{
    //    fireballExplosion = GetComponent<ParticleSystem>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;

        hitaudioSource.clip = hitaudioClip;
        hitaudioSource.playOnAwake = false;

        Range = 20f;
        Damage = 14;
        GetComponent<Rigidbody>().AddForce(Direction * 50f); //Move the object using Physics engine
        spawnPosition = transform.position;

        audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            ExtinguishFireball();
        }
    }

    void ExtinguishFireball()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hitaudioClip, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        fireballExplosion.Play();

        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        
        ExtinguishFireball();
    }
}
