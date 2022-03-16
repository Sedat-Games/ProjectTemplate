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

    [Header("Level Achivement Objects")]
    public List<GameObject> achivementObjects;
    public List<int> achimentLevelNumbers;

 

    IEnumerator Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.5f);

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

        
        if(achivementObjects.Count > 0)
        {
            for (int i = 0; i < achivementObjects.Count; i++)
            {
                var tempAchivementObj = Instantiate(achivementObjects[i], levelMapObjHolder.transform);
                tempAchivementObj.transform.localPosition = new Vector3(tempAchivementObj.transform.localPosition.x, ((achimentLevelNumbers[i] - 1) * posIncreaseAmount) - 800, 0);
            }         
           
        }

        yield return null;
    }

     
}
