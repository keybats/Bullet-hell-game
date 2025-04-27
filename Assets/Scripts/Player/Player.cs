using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Player
{
    public static string currentSceneName;
    public static int enemyIDs;
    public static Vector2 overworldLocation;
    public static float maxHitPoints = 100;
    //public static float currentHitPoints = 100;
    public static List<Weapon> weaponInventory;
    public static List<SpAtk> spAtkInventory;
    public static List<Weapon> equippedWeapons;
    public static SpAtk equippedSpAtk;
}
