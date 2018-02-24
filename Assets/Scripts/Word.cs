#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 16:45

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BabylonJam
{
    internal class Word : MonoBehaviour, IPointerClickHandler
    {
        private RectTransform rect;
        private Vector2 target;
        private const float speed = 10f;
        private bool isMoving = false;
        private bool onBag = true;

        private void Awake()
        {
            rect = GetComponent<RectTransform>(); 
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (onBag)
            {
                SentenceBar.Instance.RegisterRect(rect);
                transform.SetParent(SentenceBar.Instance.transform); 
                target = SentenceBar.Instance.SlotPosition;
                isMoving = true;
                onBag = false;
            }
            else
            {
                SentenceBar.Instance.UnRegisterRect(rect);
                transform.SetParent(WordBag.Instance.transform);
                target = WordBag.Instance.EmptyPosition;
                isMoving = true;
                onBag = true;
            }
        }

        private void Update()
        {
            if (isMoving)
            {
                transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime * speed);

                if(Vector2.Distance(transform.position, target) < 1f)
                {
                    transform.position = target;
                    isMoving = false;                   
                }
            }
        }
    }
}