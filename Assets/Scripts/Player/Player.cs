using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CharactersStats charactersStats;
    public int currentHealth;
    public int maxHealth;
    public PlayerLevel PlayerLevel { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLevel = GetComponent<PlayerLevel>();
        this.currentHealth = this.maxHealth;
        charactersStats = new CharactersStats(10, 10, 10);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    private void Die()
    {
        Debug.Log("Player's dead. Resetting level");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //this.currentHealth = this.maxHealth;
        //UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    public void RegainHealth(int amount)
    {
        this.currentHealth = this.currentHealth + amount;
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }
}
