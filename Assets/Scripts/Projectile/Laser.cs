using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    //public Transform lineEndPoint;
    public float range = 100f;
    public float damage = 1;
    LayerMask layerMask;
    LayerMask playerMask;
    bool isPlayerImmuneToLazer = false;
    bool isLaserActive = false;

    private void Start()
    {
        
        Debug.Log("line renderer found: " + line);
        layerMask = LayerMask.GetMask("Laser");
        playerMask = LayerMask.GetMask("Player");
    }

    public void ActivateLaser()
    {
        isLaserActive = true;
        line.enabled = true;
        line.SetPosition(0, transform.position);

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, -transform.right, range, layerMask);
        if (raycastHit)
        {
            Debug.Log("hit");
            line.SetPosition(1, raycastHit.point);
        }
        else
        {
            Debug.Log("no hit");
            line.SetPosition(1, transform.position);
        }
    }

    public void DeactivateLaser()
    {
        line.enabled = false;
        isLaserActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLaserActive)
        {
            line.SetPosition(0, transform.position);

            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, -transform.right, range, layerMask);
            if (raycastHit)
            {
                line.SetPosition(1, raycastHit.point);
            }
            else
            {
                line.SetPosition(1, transform.position);
            }
            RaycastHit2D damageLaser = Physics2D.Raycast(transform.position, -transform.right, range, playerMask);
            if (damageLaser && !isPlayerImmuneToLazer)
            {
                isPlayerImmuneToLazer = true;
                damageLaser.collider.GetComponent<PlayerHP>().TakeDamage(damage);
                Invoke("ResetPlayerLaserImmunity", 1);
            }
        }
    }
    void ResetPlayerLaserImmunity()
    {
        isPlayerImmuneToLazer = false;
    }
}
