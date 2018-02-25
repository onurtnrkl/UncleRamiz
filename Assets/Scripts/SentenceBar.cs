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
        private List<Word> guess;

        public bool Busy;

        public void SetAnswer(string[] answer)
        {
            this.answer = answer;
            guess.Clear();
        }

        public void RegisterWord(Word word)
        {
            guess.Add(word);
        }

        public bool MaxSentence
        {
            get
            {
                return answer.Length == guess.Count;
            }

        }

        public void UnRegisterWord(Word word)
        {
            guess.Remove(word);
            FixedPosition();
        }

        private void FixedPosition()
        {
            for (int i = 0; i < guess.Count; i++)
                guess[i].transform.position = IndexPosition(i);
        }

        public void CheckAnswer()
        {
            if (IsAnswerCorrect)
            {
                Grandpa.Instance.NextStep();
            }
            else
            {
                Grandpa.Instance.Bubble.SetDialog("I don't understand.");
                Grandpa.Instance.Bubble.Show(3f);
            }
                
            QuestManager.Instance.ResetContext();
        }

        private bool IsAnswerCorrect
        {
            get
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    if (!answer[i].Equals(guess[i].Text))
                        return false;
                }

                return true;
            }
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
                return IndexPosition(guess.Count);
            }
        }

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            guess = new List<Word>();
        }
    }
}