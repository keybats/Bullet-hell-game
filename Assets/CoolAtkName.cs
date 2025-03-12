using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolAtkName : MonoBehaviour
{
    bool firstTime = true;
    Vector2 atkPosition;
    [SerializeField] Projectile projectile;
    [SerializeField] int volleys;
    [SerializeField] int columns;
    [SerializeField] float angle;
    [SerializeField] float pspeed;
    [SerializeField] float damage;
    [SerializeField] float delay;
    private void OnEnable()
    {
        if(firstTime)
        {
            firstTime = false;
            return;
        }
        PlayerController player = FindObjectOfType<PlayerController>();
        atkPosition = player.transform.position;
        StartCoroutine("FireTheCoolAttack");
    }
    IEnumerator FireTheCoolAttack()
    {
        for (int i = 0; i < volleys; i++)
        {

            Projectile p = Instantiate(projectile, atkPosition, transform.rotation);
            p.SetProjectileStats(pspeed, columns, angle, -90, true, damage);
            yield return new WaitForSeconds(delay);
        }
        gameObject.SetActive(false);
    }
}
