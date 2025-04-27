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
    SpAtk spAtk;
    [SerializeField] float chargeIncrement;

    
    
    void Start()
    {
        
        spAtkBar = GameObject.Find("SpecialBarFill").GetComponent<Image>();
        spAtk = Instantiate(Player.equippedSpAtk).GetComponent<SpAtk>();
        this.maxCharge = spAtk.maxCharge;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collision!");

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
        spAtkBar.fillAmount = charge/maxCharge;
        if (charge > maxCharge)
        {
            charge = maxCharge;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(SpAtkKey) && charge == maxCharge)
        {
            spAtk.RelaySpAtkActivation();
            charge = 0;
            spAtkBar.fillAmount = charge;
        }
    }
    
    

}
