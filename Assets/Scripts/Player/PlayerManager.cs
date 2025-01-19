using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static Player player;
    public KeyCode inventoryKey = KeyCode.E;

    [SerializeField] List<Weapon> weaponInventory;
    [SerializeField] List<Weapon> equippedWeapons;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] WeaponInInventory weaponInInventoryTemplate;
    [SerializeField] Vector2 inventoryStartPos;
    [SerializeField] float distanceBetweenItems;

    bool isInventoryOpen;
    
    
    
    
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


    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            if (!isInventoryOpen)
            {
                Debug.Log("Opening inventory");
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    void OpenInventory()
    {
        inventoryPanel.SetActive(true);

        foreach(Weapon weapon in Player.weaponInventory)
        {
            WeaponInInventory w = Instantiate(weaponInInventoryTemplate, inventoryPanel.transform);
            w.GetComponent<RectTransform>().position = inventoryStartPos;
            Debug.Log(weapon.name);
            w.correspondingWeapon = weapon;
            Debug.Log(w.correspondingWeapon.name);
            w.isEquipped = Player.equippedWeapons.Contains(weapon);
            w.SetText();
            inventoryStartPos = new Vector2(inventoryStartPos.x, inventoryStartPos.y - distanceBetweenItems);
        }
    }
    void CloseInventory()
    {

    }
}
