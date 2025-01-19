using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] float firingSpeed;
    [SerializeField] float projectileSpawnDistance;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileDirection;
    [SerializeField] int projectileAmount;
    [SerializeField] float projectileSpread;
    [SerializeField] string name;

    
    public float moveSpeedReductionOnFire;
    public bool isFiring;



    private void OnEnable()
    {

        isFiring = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !isFiring)
        {
            StartCoroutine(Fire());
        }
    }

    public IEnumerator Fire()
    {
        isFiring = true;

        if (isFiring)
        {
            Projectile p = Instantiate(projectile, transform.position + new Vector3(projectileSpawnDistance, 0), transform.rotation);
            p.SetProjectileStats(projectileSpeed, projectileAmount , projectileSpread, projectileDirection, true);
            
        }
        yield return new WaitForSeconds(firingSpeed);
        isFiring = false;
    }

}




// bass bass base 