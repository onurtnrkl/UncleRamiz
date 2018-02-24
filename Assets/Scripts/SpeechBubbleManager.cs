#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       23/02/2018 22:50

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

namespace BabylonJam
{
    internal class SpeechBubbleManager : MonoBehaviour
    {
        private static SpeechBubbleManager instance;

        private SpeechBubbleView view;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Initialize();
            }
            else Destroy(gameObject);
        }

        private void Initialize()
        {
            view = Instantiate(Resources.Load<GameObject>("Prefabs/SpeechBubble"), transform).GetComponent<SpeechBubbleView>();
        }

        public static void Open(RectTransform rect, string text)
        {
            SpeechBubbleView view = instance.view;

            view.SetDialog(text);
            view.SetPosition(rect);
            view.Show();
        }
    }    
}