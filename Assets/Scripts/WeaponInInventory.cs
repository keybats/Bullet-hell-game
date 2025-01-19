using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponInInventory : MonoBehaviour
{
    public bool isEquipped;
    public Weapon correspondingWeapon;
    [SerializeField] TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleEquip()
    {
        if (isEquipped)
        {
            isEquipped = false;
            Player.equippedWeapons.Remove(correspondingWeapon);
            buttonText.text = correspondingWeapon.name;
        }
        else if (Player.equippedWeapons.Count < 2)
        {
            isEquipped = true;
            Player.equippedWeapons.Add(correspondingWeapon);
            buttonText.text = correspondingWeapon.name + " - equipped";
        }
        else
        {
            Debug.Log("already have 2 equipped weapons");
        }
    }
    public void SetText()
    {
        if (isEquipped)
        {
            buttonText.text = correspondingWeapon.name + " - equipped";
        }
        else
        {
            buttonText.text = correspondingWeapon.name;
        }
        
    }
}
