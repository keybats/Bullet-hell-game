using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Weapon ItemToBePickedUp;



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("netrf");
    //    if (collision.gameObject.GetComponent<PlayerController>())
    //    {

    //    }
    //}
    public void AddToInventory()
    {
        Player.weaponInventory.Add(ItemToBePickedUp);
        Destroy(gameObject);
    }
}
