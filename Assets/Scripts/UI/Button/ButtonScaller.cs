using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float finalScale = 1.2f;
    public float scaleDuration = .1f;
    public float scaleDurationLogo = .3f;

    public Transform button;
    public Transform logo;

    private Vector3 _defaultScale;



    private Tween _currentTween;
    private Tween _currentTween2;
    private bool onclickbool;
    private Vector3 transformbutton;

    public List<Typper> listofPhrases;

    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    private void Start()
    {
        onclickbool = false;
        transformbutton = Vector3.one;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!onclickbool)
        {
            _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration);
            _currentTween2 = logo.transform.DOScaleY(0, scaleDurationLogo);

            if (listofPhrases != null)
            {
                for (int i = 0; i < listofPhrases.Count; i++)
                {
                    listofPhrases[i].startTypeAprove();
                }
                Invoke(nameof(startType), scaleDurationLogo * 1f);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!onclickbool)
        {
            OnPointerExitVoid();
        }
    }

    private void OnPointerExitVoid()
    {
        _currentTween.Kill();
        _currentTween2.Kill();
        transform.localScale = _defaultScale;
        logo.transform.DOScaleY(1, scaleDuration);

        for (int i = 0; i < listofPhrases.Count; i++)
        {
            listofPhrases[i].EraseTest();
        }
        CancelInvoke();
    }

    private void startType()
    {
        for (int i = 0; i < listofPhrases.Count; i++)
        {
            listofPhrases[i].startType();
        }
    }

    public void Onclick()
    {
        onclickbool = true;
        _currentTween2 = button.transform.DOScale(0, scaleDurationLogo);
        button.transform.DOScale(transformbutton, scaleDuration).SetDelay(3f);
        Invoke(nameof(TimeS), 3f);
    }

    public void TimeS()
    {
        onclickbool = false;
        OnPointerExitVoid();
    }
}
