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
        private LayoutElement layout;
        private Text text;
        private Vector2 target;
        private int bagIndex = -1;
        private const float speed = 10f;
        private bool isMoving = false;
        private bool onBag = false;

        public void SetBagIndex(int index)
        {
            bagIndex = index;
        }

        public string Text
        {
            get
            {
                return text.text;
            }
            set
            {
                text.text = value;
            }
        }

        public void Move(Vector2 target, Transform parent)
        {
            transform.SetParent(parent);
            this.target = target;
            onBag = !onBag;
            isMoving = true;
        }

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            layout = GetComponent<LayoutElement>();
            text = GetComponentInChildren<Text>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (onBag)
            {
                Vector2 position = SentenceBar.Instance.SlotPosition;
                SentenceBar.Instance.RegisterWord(this);
                Move(position, SentenceBar.Instance.transform);
            }
            else
            {
                SentenceBar.Instance.UnRegisterWord(this);
                Move(WordBag.Instance.SlotPosition(bagIndex), WordBag.Instance.transform);
            }
        }

        private void Update()
        {
            if (isMoving)
            {
                transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime * speed);

                if(Vector2.Distance(transform.position, target) < 1f)
                {
                    layout.ignoreLayout = onBag;
                    transform.position = target;
                    isMoving = false;                   
                }
            }
        }
    }
}