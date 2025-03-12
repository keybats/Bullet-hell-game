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
    public GameObject prefabSpAtk;
    GameObject spAtk;

    
    
    void Start()
    {
        
        spAtkBar = GameObject.Find("SpecialBarFill").GetComponent<Image>();
        spAtk = Instantiate(prefabSpAtk);
        spAtk.SetActive(false);
        
    }


    public void GainCharge(float gainedCharge)
    {
        charge += gainedCharge;
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
