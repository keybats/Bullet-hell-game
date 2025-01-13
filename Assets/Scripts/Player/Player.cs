using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Player
{
    public static int enemyIDs;
    public static Vector2 overworldLocation;
    public static float maxHitPoints = 100;
    //public static float currentHitPoints = 100;
    public static List<Weapon> weaponInventory;
    public static List<Weapon> equippedWeapons;
}
