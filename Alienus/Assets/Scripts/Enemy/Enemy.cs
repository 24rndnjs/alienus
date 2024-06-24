using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public float space;
    private int currentHP;
    public GameObject closestPlayer;

    void Start()
    {
        currentHP = enemyData.maxHP;
    }

    void Update()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag("player");

        FindClosestPlayer(players);

        if (closestPlayer != null)
        {

            Vector3 direction = closestPlayer.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.position = Vector2.MoveTowards(this.transform.position, closestPlayer.transform.position, enemyData.speed * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, closestPlayer.transform.position);

        }
    }

    void FindClosestPlayer(GameObject[] players)
    {
        float minDistance = Mathf.Infinity;
        closestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= space && distance < minDistance)
            {
                minDistance = distance;
                closestPlayer = player;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(space, space, space));

    }
    public void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(damage - enemyData.defense, 0);
        currentHP -= actualDamage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
