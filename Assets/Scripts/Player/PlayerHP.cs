using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    float maxHealth;
    [SerializeField] TextMeshProUGUI playerHPDisplay;

    float currentHealth;
    
    void Start()
    {
        maxHealth = Player.maxHitPoints;
        currentHealth = maxHealth;
        //currentHealth = Player.currentHitPoints;
        playerHPDisplay.text = "HP: " + currentHealth;
    }

    
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playerHPDisplay.text = "HP: " + currentHealth;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    /*
    public void BattleReset()
    {

    }
    */
}
