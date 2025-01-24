using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Weapon ItemToBePickedUp;




    public void AddToInventory()
    {
        Player.weaponInventory.Add(ItemToBePickedUp);
        Destroy(gameObject);
    }
}
