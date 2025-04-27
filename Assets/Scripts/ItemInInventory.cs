using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInInventory : MonoBehaviour
{
    public GameObject empty;
    public enum ItemType { Weapon, SpAtk }
    public ItemType itemType;
    public bool isEquipped;
    public GameObject correspondingItem;
    //public Weapon correspondingWeapon;
    //public GameObject correspondingSpAtk;
    [SerializeField] TextMeshProUGUI buttonText;
    public PlayerManager playerManager;

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
            if (itemType == ItemType.Weapon)
            {
                Player.equippedWeapons.Remove(correspondingItem.GetComponent<Weapon>());
            }
            else if (itemType == ItemType.SpAtk)
            {
                Player.equippedSpAtk = null;
            }
            buttonText.text = correspondingItem.name;
        }
        else if (Player.equippedWeapons.Count < 2 && itemType == ItemType.Weapon)
        {
            isEquipped = true;
            Player.equippedWeapons.Add(correspondingItem.GetComponent<Weapon>());
            buttonText.text = correspondingItem.name + " - equipped";
        }
        else if (itemType == ItemType.Weapon)
        {
            Debug.Log("already have 2 equipped weapons");
        }
        else if (itemType == ItemType.SpAtk)
        {
            if (Player.equippedSpAtk != empty)
            {
                foreach (ItemInInventory item in playerManager.InstantiatedItemsInInventory)
                {
                    if (item.itemType == ItemType.SpAtk && item.isEquipped)
                    {
                        item.ToggleEquip();
                    }
                }
            }
            isEquipped = true;
            Player.equippedSpAtk = correspondingItem.GetComponent<SpAtk>();
            buttonText.text = correspondingItem.name + " - equipped";
        }
    }
    public void SetText()
    {
        if (isEquipped)
        {
            buttonText.text = correspondingItem.name + " - equipped";
        }
        else
        {
            buttonText.text = correspondingItem.name;
        }
        
    }
}
