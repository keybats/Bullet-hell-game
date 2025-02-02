using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightInitiator : MonoBehaviour
{
    [SerializeField] int fightID;
    public void StartBattle()
    {
        Player.enemyIDs = fightID;
        PlayerManager manager = FindObjectOfType<PlayerManager>();
        manager.OnEncounter();
        SceneManager.LoadScene(1);
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("Collision has happened");
    //    if (collision.gameObject.GetComponent<PlayerController>())
    //    {
    //        StartBattle();
    //    }
    //}


}
