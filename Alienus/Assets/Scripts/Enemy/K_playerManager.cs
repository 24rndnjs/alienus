using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_playerManager : MonoBehaviour
{
    #region singleton
    public static K_playerManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject Player;
}
