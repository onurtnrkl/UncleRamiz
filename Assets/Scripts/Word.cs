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
            text = GetComponentInChildren<Text>();
        }

        private void OnDisable()
        {
            target = transform.localPosition;
            onBag = true;
            isMoving = false;
        }

        public void GoToBag()
        {
            SentenceBar.Instance.UnRegisterWord(this);
            Move(WordBag.Instance.SlotPosition(bagIndex), WordBag.Instance.transform);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (onBag)
            {
                if (SentenceBar.Instance.MaxSentence) return;

                Vector2 position = SentenceBar.Instance.SlotPosition;
                SentenceBar.Instance.RegisterWord(this);
                SentenceBar.Instance.Busy = true;
                Move(position, SentenceBar.Instance.transform);
            }
            else
            {
                if (SentenceBar.Instance.Busy) return;
                GoToBag();
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

                    if (!onBag)
                    {
                        SentenceBar.Instance.Busy = false;

                        if (SentenceBar.Instance.MaxSentence)
                            SentenceBar.Instance.CheckAnswer();
                    }
                }
            }
        }
    }
}