using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
    [SerializeField] BootScript player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
