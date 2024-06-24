using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostKnightskill : MonoBehaviour
{
    public EnemyData ghostKnight;
    public float speedIncreaseAmount = 3f;
    public float cooltime = 3f;

    void Start()
    {
        StartCoroutine(CoolTime());
    }

    IEnumerator CoolTime()
    {
        float cooltime = 0f;

      
        while (cooltime < this.cooltime)
        {
            ghostKnight.speed += speedIncreaseAmount * Time.deltaTime / this.cooltime;
            cooltime += Time.deltaTime;
            yield return null;
        }

        
        while (cooltime > 0f)
        {
            ghostKnight.speed -= speedIncreaseAmount * Time.deltaTime / this.cooltime;
            cooltime -= Time.deltaTime;
            yield return null;
        }

        ghostKnight.speed = 3;
    }

}
