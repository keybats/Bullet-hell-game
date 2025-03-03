using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    CombatManager combatManager;
    [SerializeField] float maxHealth;
    [SerializeReference] float currentHealth;
     Image bossHPBar;
    
    void Start()
    {
        combatManager = FindObjectOfType<CombatManager>();
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
        if (currentHealth <= 0)
        {
            combatManager.OnBattleEnd();
        }
    }
}
