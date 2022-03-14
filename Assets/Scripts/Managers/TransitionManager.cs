using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TransitionManager : MonoBehaviour
{
    [Header("Enter Trasition Time")]
    [SerializeField] private float transitionTime;
    [Space(10)]
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI fillText;

    private float loadingNumber;

    void Start()
    {
        fillImage.fillAmount = 0;
        DOTween.To(() => loadingNumber, x => loadingNumber = x, 100, transitionTime).OnUpdate(() =>
        {
            fillText.text = Mathf.Round(loadingNumber).ToString();
        });
        DOTween.To(() => fillImage.fillAmount, x => fillImage.fillAmount = x, 1, transitionTime)
            .OnComplete(() => gameObject.transform.DOScale(Vector3.zero,0.2f).SetEase(Ease.InCirc)
            .OnComplete(() => gameObject.SetActive(false)));

    }



}
