using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static Player player;
    List<Weapon> weaponInventory;
    [SerializeField] List<Weapon> equippedWeapons;
    
    
    // Start is called before the first frame update
    void Start()
    {

        
        Player.overworldLocation = transform.position;
        Player.weaponInventory = weaponInventory;
        Player.equippedWeapons = equippedWeapons;
    }

    public void OnEncounter()
    {
        Player.overworldLocation = transform.position;
        Player.weaponInventory = this.weaponInventory;
        Player.equippedWeapons = this.equippedWeapons;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
