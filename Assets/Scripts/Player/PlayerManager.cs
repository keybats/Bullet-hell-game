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


    
    List<WeaponInInventory> InstantiatedWeaponsInInventory;
    Vector2 inventoryPosition;
    bool isInventoryOpen;
    
    
    
    
    void Start()
    {
        Player.overworldLocation = transform.position;
        Player.weaponInventory = weaponInventory;
        Player.equippedWeapons = equippedWeapons;
        InstantiatedWeaponsInInventory = new List<WeaponInInventory>();

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
        inventoryPosition = inventoryStartPos;
        isInventoryOpen = true;
        inventoryPanel.SetActive(true);
        
        foreach (Weapon weapon in Player.weaponInventory)
        {
            WeaponInInventory w = Instantiate(weaponInInventoryTemplate, inventoryPanel.transform);
            w.GetComponent<RectTransform>().position = inventoryPosition;
            Debug.Log(weapon.name);
            w.correspondingWeapon = weapon;
            w.isEquipped = Player.equippedWeapons.Contains(weapon);
            w.SetText();
            inventoryPosition = new Vector2(inventoryPosition.x, inventoryPosition.y - distanceBetweenItems);
            //Debug.Log(w.gameObject);
            InstantiatedWeaponsInInventory.Add(w);
        }
    }
    void CloseInventory()
    {
        foreach (WeaponInInventory weapon in InstantiatedWeaponsInInventory)
        {
            Debug.Log("destroying a weapon");
            Destroy(weapon.gameObject);
        }
        InstantiatedWeaponsInInventory.Clear();
        Debug.Log("disbling invnentory");
        inventoryPanel.SetActive(false);
        isInventoryOpen = false;
    }
}
