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
        private List<Word> current;

        public void SetAnswer(string[] answer)
        {
            this.answer = answer;
            current.Clear();
        }

        public void RegisterWord(Word word)
        {
            current.Add(word);
            Debug.Log(word + " registered.");
            Debug.Log("current length= " + (current.Count));
        }

        public void UnRegisterWord(Word word)
        {
            current.Remove(word);
            FixedPosition();
        }

        private void FixedPosition()
        {
            for (int i = 0; i < current.Count; i++)
                current[i].transform.position = IndexPosition(i);
        }

        private Vector2 IndexPosition(int index)
        {
            float x = (260 * index) + 150;
            float y = transform.position.y;

            return new Vector2(x, y);
        }

        public Vector2 SlotPosition
        {
            get
            {
                return IndexPosition(current.Count);
            }
        }

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            current = new List<Word>();
        }
    }
}