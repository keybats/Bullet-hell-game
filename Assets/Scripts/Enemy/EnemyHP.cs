using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeReference] float currentHealth;
     Image bossHPBar;
    
    void Start()
    {
        bossHPBar = GameObject.Find("BossHPBarFill").GetComponent<Image>();
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        bossHPBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }
}
