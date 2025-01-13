using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileBehaviour : MonoBehaviour
{
    Projectile projectile;

    private void Start()
    {
        projectile = GetComponent<Projectile>();
    }

    protected void Update()
    {
        ProjectileBehaviour(projectile.GetSpeed());

    }

    void ProjectileBehaviour(float projectileSpeed)
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }
}
