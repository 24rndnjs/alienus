using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; // 적 데이터 스크립터블 오브젝트
    private int currentHP;

    public GameObject[] players; // 모든 플레이어를 담는 배열
    private GameObject closestPlayer;
    private float distance;

    void Start()
    {
        currentHP = enemyData.maxHP;
    }

    void Update()
    {
        FindClosestPlayer();

        if (closestPlayer != null)
        {
            distance = Vector2.Distance(transform.position, closestPlayer.transform.position);
            Vector2 direction = closestPlayer.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, closestPlayer.transform.position, enemyData.speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    void FindClosestPlayer()
    {
        float minDistance = Mathf.Infinity;
        closestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPlayer = player;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(damage - enemyData.defense, 0); // 방어력을 고려한 실제 피해량
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
