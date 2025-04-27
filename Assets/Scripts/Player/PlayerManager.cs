using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject empty;
    public static Player player;
    public KeyCode inventoryKey = KeyCode.E;

    [SerializeField] List<Weapon> weaponInventory;
    [SerializeField] List<Weapon> equippedWeapons;
    [SerializeField] List<SpAtk> spAttacks;
    [SerializeField] SpAtk equippedSpAtk;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] ItemInInventory ItemInInventoryTemplate;
    [SerializeField] Vector2 inventoryStartPos;
    [SerializeField] float distanceBetweenItems;
    [SerializeField] float distanceBetweenRows;


    
    public List<ItemInInventory> InstantiatedItemsInInventory;
    Vector2 inventoryPosition;
    bool isInventoryOpen;
    
    
    
    
    void Start()
    {
        Player.overworldLocation = transform.position;
        Player.weaponInventory = weaponInventory;
        Player.spAtkInventory = spAttacks;
        Player.equippedWeapons = equippedWeapons;
        Player.equippedSpAtk = equippedSpAtk;
        InstantiatedItemsInInventory = new List<ItemInInventory>();

    }

    public void OnEncounter()
    {
        Player.overworldLocation = transform.position;
        Player.weaponInventory = this.weaponInventory;
        Player.equippedWeapons = this.equippedWeapons;
        Debug.Log(SceneManager.GetActiveScene().name);
        Player.currentSceneName = SceneManager.GetActiveScene().name;
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
            ItemInInventory w = Instantiate(ItemInInventoryTemplate, inventoryPanel.transform);
            w.empty = this.empty;
            w.GetComponent<RectTransform>().position = inventoryPosition;
            //Debug.Log(weapon.name);
            w.itemType = ItemInInventory.ItemType.Weapon;
            w.correspondingItem = weapon.gameObject;
            w.isEquipped = Player.equippedWeapons.Contains(weapon);
            w.SetText();
            inventoryPosition = new Vector2(inventoryPosition.x, inventoryPosition.y - distanceBetweenItems);
            //Debug.Log(w.gameObject);
            InstantiatedItemsInInventory.Add(w);
        }

        inventoryPosition = new Vector2(inventoryPosition.x + distanceBetweenRows, inventoryStartPos.y);

        foreach (SpAtk spAtk in Player.spAtkInventory)
        {
            ItemInInventory s = Instantiate(ItemInInventoryTemplate, inventoryPanel.transform);
            s.empty = this.empty;
            s.GetComponent<RectTransform>().position = inventoryPosition;
            s.itemType = ItemInInventory.ItemType.SpAtk;
            s.playerManager = this;
            //Debug.Log("name " + spAtk.gameObject.name);
            s.correspondingItem = spAtk.gameObject;
            Debug.Log(Player.equippedSpAtk);
            s.isEquipped = Player.equippedSpAtk.Equals(spAtk);
            s.SetText();
            inventoryPosition = new Vector2(inventoryPosition.x, inventoryPosition.y - distanceBetweenItems);
            InstantiatedItemsInInventory.Add(s);
        }
    }
    void CloseInventory()
    {
        foreach (ItemInInventory weapon in InstantiatedItemsInInventory)
        {
            //Debug.Log("destroying a weapon");
            Destroy(weapon.gameObject);
        }
        InstantiatedItemsInInventory.Clear();
        Debug.Log("disbling invnentory");
        inventoryPanel.SetActive(false);
        isInventoryOpen = false;
    }
}
