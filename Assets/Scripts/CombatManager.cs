using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] Vector2 enemyStartPos;
    //[SerializeField] PlayerHP playerHP;
    [SerializeField] List<GameObject> enemyPrefabList;
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(enemyPrefabList[Player.enemyIDs], transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
