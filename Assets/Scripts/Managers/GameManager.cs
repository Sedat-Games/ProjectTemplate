using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Level Properties")]
    [SerializeField] private int maxLevelNumber;
    [SerializeField] private GameObject[] levels;
    [SerializeField] private Transform levelHolder;

    private void Awake()
    {
        levels = Resources.LoadAll<GameObject>("Levels");
        maxLevelNumber = levels.Length;
    }

    public void LoadLevel(int levelNumber)
    {
       var level = Instantiate(levels[levelNumber - 1], levelHolder);
    }

    public void DestroyLevels()
    {
        levels = GameObject.FindGameObjectsWithTag("Level");
        if(levels != null)
        {
            foreach (var level in levels)
            {
                Destroy(level);
            }
        }
    }
}
