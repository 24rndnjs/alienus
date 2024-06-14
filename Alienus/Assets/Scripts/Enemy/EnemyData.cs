using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHP;
    public int defense;
    public int attack;
    public float speed;
}