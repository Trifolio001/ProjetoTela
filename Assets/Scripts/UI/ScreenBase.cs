using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Sobre,
        Shop
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObject;

        public List<Typper> listofPhrases;

        public bool starHided = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObject = .05f;

        void Start()
        {
            if (starHided)
            {
                HideObjects();
            }
            //if(ScreenType)
            //Invoke(nameof(Show), 2f);
        }
        [Button]
        public virtual void Show()
        {
            for (int i = 0; i < listOfObject.Count; i++)
            {
                listOfObject[i].transform.localScale = Vector3.one;
            }
            ShowObjects();
            if (listofPhrases != null)
            {
                for (int i = 0; i < listofPhrases.Count; i++)
                {
                    listofPhrases[i].EraseTest();
                    listofPhrases[i].startTypeAprove();
                }
                Invoke(nameof(startType), delayBetweenObject * listOfObject.Count);
            }
        }
        [Button]
        public virtual void Hide()
        {
            HideObjects();
        }

        [Button]
        public virtual void Ocult()
        {
            OcultObjects();
        }

        private void HideObjects()
        {
            listOfObject.ForEach(i => i.gameObject.SetActive(false));
        }

        private void ShowObjects()
        {
            for(int i = 0; i < listOfObject.Count; i++)
            {
                var Obj = listOfObject[i];

                Obj.gameObject.SetActive(true);
                Obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObject);
            }
        }

        private void OcultObjects()
        {
            int reference = 0;
            for (int i = listOfObject.Count - 1; i >= 0 ; i--)
            {
                reference++;
                var Obj = listOfObject[i];
                Obj.transform.DOScale(0, animationDuration).SetDelay(reference * delayBetweenObject); ;
                //Obj.DOScale(1, animationDuration).From().SetDelay(i * delayBetweenObject);
            }
        }

        private void ForceShowObjects()
        {
            listOfObject.ForEach(i => i.gameObject.SetActive(true));
        }

        private void startType()
        {
            for (int i = 0; i < listofPhrases.Count; i++)
            {
                listofPhrases[i].startType();
            }
        }
    }
}
