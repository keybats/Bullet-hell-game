using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolAtkName : MonoBehaviour
{
    Vector2 atkPosition;
    [SerializeField] Projectile projectile;
    [SerializeField] int volleys;
    [SerializeField] int columns;
    [SerializeField] float angle;
    [SerializeField] float pspeed;
    [SerializeField] float damage;
    [SerializeField] float delay;

    public void ActivateSpAtk()
    {
        StartCoroutine(FireTheCoolAttack());
        //Debug.Log("recieved message");
    }
    IEnumerator FireTheCoolAttack()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        atkPosition = player.transform.position;
        for (int i = 0; i < volleys; i++)
        {
            Projectile p = Instantiate(projectile, atkPosition, transform.rotation);
            p.SetProjectileStats(pspeed, columns, angle, -90, true, damage);
            yield return new WaitForSeconds(delay);
        }
    }
}
