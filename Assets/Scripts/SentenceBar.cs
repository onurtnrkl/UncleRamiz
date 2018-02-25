#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 20:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
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

        private string[] answer;
        private List<string> current;

        public void SetAnswer(string[] answer)
        {
            this.answer = answer;
            current.Clear();
        }

        public void RegisterWord(string word)
        {
            current.Add(word);
            Debug.Log(word + " registered.");
            Debug.Log("current length= " + (current.Count));
        }

        public void UnRegisterWord(string word)
        {
            current.Remove(word);
        }

        public Vector2 SlotPosition
        {
            get
            {
                float x = (260 * current.Count) + 150;
                float y = transform.position.y;

                return new Vector2(x, y);
            }
        }

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            current = new List<string>();
        }
    }
}