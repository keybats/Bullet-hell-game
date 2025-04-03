using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakuya : MonoBehaviour
{
    bool firstTime = true;
    [SerializeField] float timeMod;
    [SerializeField] float duration;
    private void OnEnable()
    {
        if (firstTime)
        {
            firstTime = false;
            return;
        }
        StartCoroutine("BulletTime");
    }
    IEnumerator BulletTime()
    {
        Debug.Log("time slow");
        Time.timeScale = timeMod;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
