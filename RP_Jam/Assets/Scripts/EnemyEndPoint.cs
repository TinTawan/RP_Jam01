using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
    [SerializeField] BootScript player;
    [SerializeField] UI_Manager ui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyEnters(other);
        }
    }

    void EnemyEnters(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        enemy.ReachedTarget();
        player.AddIdeologyVal(-enemy.GetIdeologyLevel()*2);

        ui.PopEnemyFromList();
    }
}
