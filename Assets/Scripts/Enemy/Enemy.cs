using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool alive = false;
    public List<EnemyMove> moves;
    bool isBusy = false;
    [SerializeField] Laser laser;

    private void Start()
    {
        //laser = GetComponentInChildren<Laser>();
        //laser.gameObject.SetActive(false);
        //StartCoroutine(ActivateLaser(90f, -45, 1f, 1f));
        
    }

    void Update()
    {
        if (!isBusy && alive)
        {
            EnemyMove currentMove = moves[Random.Range(0, moves.Count)];

            //Debug.Log(currentMove.name);

            StartCoroutine(MoveToStartPos(currentMove));
            isBusy = true;
        }
    }

    private IEnumerator MoveToStartPos(EnemyMove currentMove)
    {
        

        Vector2 startPos = transform.position;
        Vector2 endPos = currentMove.startPosition;

        float travelPercent = 0f;


        while (travelPercent < 1)
        {
            travelPercent += Time.deltaTime * currentMove.startPosSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(Move(currentMove));
        StartCoroutine(Attack(currentMove));
    }

    

    private IEnumerator Move (EnemyMove currentMove)  
    {
        
        int i = 0;
        float startTime = Time.unscaledTime;
        foreach (Movement movement in currentMove.movements)
        {

            Vector2 startPos = transform.position;
            Vector2 endPos = movement.movementPosition;

            float travelPercent = 0f;


            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * movement.movementSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                //Debug.Log("going to " + endPos + ". speed " + currentMove.movementSpeeds[i] + ". i is " + i + " . travel percent is " + travelPercent);
                yield return new WaitForFixedUpdate();
            }

            

            i++;
        }
        //Debug.Log("Move time: " + Mathf.Round((Time.unscaledTime - startTime) * 100) + " (cs)");
        isBusy = false;
    }

    //time = 1/speed s (approximately)

    IEnumerator Attack(EnemyMove currentMove)
    {
        
        foreach (Attack attack in currentMove.attacks)
        {
            
            yield return new WaitForSeconds(attack.attackCooldown);
            Vector2 projectileSpawnPoint;
            if (attack.originatesFromEnemy)
            {
                projectileSpawnPoint = transform.position;
            }
            else
            {
                projectileSpawnPoint = attack.peojectileSpawnPoint;
            }
            //Debug.Log("deciding if laser or not");
            if (attack.isLaser)
            {
                StartCoroutine(ActivateLaser(attack.laserRotation, attack.laserStartRotation, attack.laserDuration, attack.damage));
                yield return new WaitForSeconds(attack.laserDuration);
            }
            else
            {
                //Debug.Log("not laser");
                Projectile p = Instantiate(attack.projectile, projectileSpawnPoint, attack.projectile.transform.rotation);
                p.SetProjectileStats(attack.projectileSpeed, attack.projectileAmount, attack.projectileSpread, attack.projectileRotation, false);
            }

        }
    }

    IEnumerator ActivateLaser(float rotation, float startingRotation, float activationDuration, float damage)
    {
        Debug.Log("laser activated");

        laser.ActivateLaser();
        laser.transform.eulerAngles = new Vector3(0, 0, startingRotation);
        float rotationPercent = 0f;
        float rotationSpeed = 1 / activationDuration; 

        while (rotationPercent < 1)
        {
            rotationPercent += Time.deltaTime * rotationSpeed;
            laser.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(startingRotation, startingRotation + rotation, rotationPercent));
            yield return new WaitForEndOfFrame();
        }
        laser.DeactivateLaser();

    }


}
