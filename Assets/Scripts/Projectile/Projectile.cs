using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    float spread;
    [SerializeField] float damage;
    //int projectileAmount;
    Rigidbody2D rb;
    bool playerProjectile = false;
    
    public float GetSpeed()
    {
        return speed;
    }

    public void SetProjectileStats(float projectileSpeed, int projectileAmount, float projectileSpread, float projectileRotation, bool isPlayerProjectile, float projectileDamage)
    {
        speed = projectileSpeed;
        spread = projectileSpread;
        playerProjectile = isPlayerProjectile;
        damage = projectileDamage;
        
        transform.Rotate(0, 0, projectileRotation + spread / 2);
        for(int i = 1; i < projectileAmount; i++)
        {
            Projectile p = Instantiate(this, transform.position, transform.rotation);
            p.SetProjectileStats(projectileSpeed, 0, 0f, 0, isPlayerProjectile, projectileDamage);
            p.transform.Rotate(0, 0, -spread / (projectileAmount - 1) * i);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHP>() && playerProjectile)
        {
            //Debug.LogWarning("Lucas, oj nej din pizza");
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
            //Debug.Log("yo 3");

            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<PlayerHP>() && !playerProjectile)
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(damage);
            //Debug.Log("yo 2");
            Destroy(gameObject);

        }
        else if (collision.gameObject.GetComponent<SpAtkCharge>() && !playerProjectile)
        {
            collision.gameObject.GetComponent<SpAtkCharge>().GainCharge(0.1f);
        }
        else if (collision.gameObject.GetComponent<Walls>())
        {
            Destroy(gameObject);

            
        }
        
    }
}
