using UnityEngine;
using TMPro;


/// <summary>
/// Child Order
/// 0 - Active
/// 1 - Shine
/// 2 - NotActive
/// 4 - LevelText
/// </summary>
public class LevelMapObjSetting : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private GameObject activeImage;
    [SerializeField] private GameObject notActiveImage;
    [SerializeField] private GameObject shineImage;

    private void Awake()
    {
        activeImage = transform.GetChild(0).gameObject;
        shineImage = transform.GetChild(1).gameObject;
        notActiveImage = transform.GetChild(2).gameObject;
        levelNumberText = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        var levelNumber = transform.GetSiblingIndex();
        levelNumberText.text = levelNumber.ToString();
    }

    public void ActivateLevel()
    {
        activeImage.SetActive(true);
        shineImage.SetActive(false);
        notActiveImage.SetActive(false);
    }

    public void DeactivateLevel()
    {
        activeImage.SetActive(false);
        shineImage.SetActive(false);
        notActiveImage.SetActive(true);
    }
    public void ShineLevel()
    {
        shineImage.SetActive(true);
    }





}
