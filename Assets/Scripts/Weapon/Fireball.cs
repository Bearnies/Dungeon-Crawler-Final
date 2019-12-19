using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        Range = 20f;
        Damage = 4;
        GetComponent<Rigidbody>().AddForce(Direction * 50f); //Move the object using Physics engine
        spawnPosition = transform.position;
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
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        ExtinguishFireball();
    }
}
