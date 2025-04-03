using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpAtkCharge : MonoBehaviour
{
    float maxCharge = 1;
    float charge = 0;
    Image spAtkBar;
    public KeyCode SpAtkKey;
    GameObject spAtk;
    [SerializeField] float chargeIncrement;

    
    
    void Start()
    {
        
        spAtkBar = GameObject.Find("SpecialBarFill").GetComponent<Image>();
        spAtk = Instantiate(Player.equippedSpAtk);
        spAtk.SetActive(false);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collision!");

        if (collision.gameObject.GetComponent<Projectile>())
        {
            if (!collision.gameObject.GetComponent<Projectile>().playerProjectile)
            {
                GainCharge();
            }
        }
    }

    public void GainCharge()
    {
        charge += chargeIncrement;
        spAtkBar.fillAmount = charge;
        if (charge > maxCharge)
        {
            charge = maxCharge;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(SpAtkKey) && charge == maxCharge)
        {
            spAtk.SetActive(true);
            charge = 0;
            spAtkBar.fillAmount = charge;
        }
    }
    
    

}
