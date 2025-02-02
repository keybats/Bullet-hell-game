using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] Vector2 enemyStartPos;
    //[SerializeField] PlayerHP playerHP;
    [SerializeField] List<GameObject> enemyPrefabList;

    void Start()
    {
        
        Instantiate(enemyPrefabList[Player.enemyIDs], transform);
    }


}
