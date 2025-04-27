using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    
    [SerializeField] Vector2 enemyStartPos;
    //[SerializeField] PlayerHP playerHP;
    [SerializeField] List<GameObject> enemyPrefabList;

    void Start()
    {
        //Instantiate(Player.equippedSpAtk);
        Instantiate(enemyPrefabList[Player.enemyIDs], transform);
        //Debug.Log(Player.currentSceneName);
    }
    public void OnBattleEnd()
    {
        SceneManager.LoadScene(Player.currentSceneName);
    }

}
