using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakuya : MonoBehaviour
{
    [SerializeField] float timeMod;
    [SerializeField] float duration;
    public void ActivateSpAtk()
    {
        StartCoroutine(BulletTime());
    }
    IEnumerator BulletTime()
    {
        Debug.Log("time slow");
        Time.timeScale = timeMod;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
