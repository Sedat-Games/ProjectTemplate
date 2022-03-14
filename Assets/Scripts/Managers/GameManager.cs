using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;

    private void Awake()
    {
        levels = Resources.LoadAll<GameObject>("Levels");   
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
