#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 20:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System;
using UnityEngine;

namespace BabylonJam
{
    internal class SentenceBar : MonoBehaviour
    {
        private static SentenceBar instance;

        public static SentenceBar Instance
        {
            get
            {
                return instance;
            }
        }

        float width = 0;

        public void RegisterRect(RectTransform rect)
        {
            if ((int)width == 0)
                width += rect.sizeDelta.x / 2;
            else
                width += rect.sizeDelta.x + 10;
        }

        public void UnRegisterRect(RectTransform rect)
        {
            width -= rect.sizeDelta.x/2 - 10;
        }

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
        }

        public Vector2 SlotPosition
        {
            get
            {
                return new Vector2(width, 550);  
            }
        }
    }
}