using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelMapManager : MonoBehaviour
{
    [SerializeField] private int maxLevelNumber;
    [SerializeField] private int currentLevel;
    [SerializeField] private GameObject levelNumberObj;
    [SerializeField] Vector3 startPos;
    [SerializeField] GameObject levelBorder;
    [SerializeField] float posIncreaseValue;
    [SerializeField] float posIncreaseAmount;
    [SerializeField] GameObject levelMapObjHolder;

    void Start()
    {
        levelBorder.transform.localScale = new Vector3(
            levelBorder.transform.localScale.x,
            levelBorder.transform.localScale.y * maxLevelNumber,
            levelBorder.transform.localScale.z);

        for (int i = 0; i < maxLevelNumber + 5; i++)
        {
            var tempLevelNumberObj = Instantiate(levelNumberObj, levelMapObjHolder.transform);
            tempLevelNumberObj.transform.localPosition = startPos + new Vector3(0, posIncreaseValue, 0);
            posIncreaseValue += posIncreaseAmount;
            LevelMapObjSetting levelMapObjSetting = tempLevelNumberObj.GetComponent<LevelMapObjSetting>();

            if (i < currentLevel)
            {
                levelMapObjSetting.ActivateLevel();
            }
            else
            {
                levelMapObjSetting.DeactivateLevel();
            }
            if (i == currentLevel) levelMapObjSetting.ShineLevel();

        }

        if(currentLevel > 5)
        {
            levelMapObjHolder.transform.DOLocalMoveY(posIncreaseAmount * -(currentLevel - 2), 1);
        }
 

    }

}
