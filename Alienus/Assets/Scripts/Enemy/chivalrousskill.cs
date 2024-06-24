using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;


public class chivalrousskill : MonoBehaviour
{

    
    public EnemyData ghost;
    public EnemyData servant;
    public EnemyData commander;
    public EnemyData infantry;
    
    void Start()
    {
        ghost.defense += 3;
        servant.defense += 3;
        commander.defense += 3;
        infantry.defense += 3; 
    }
    void Update()
    {
       
    }
    void OnDestroy()
    {
        ghost.defense -= 3;
        servant.defense -= 3;
        commander.defense -= 3;
        infantry.defense -= 3;
    }
}
