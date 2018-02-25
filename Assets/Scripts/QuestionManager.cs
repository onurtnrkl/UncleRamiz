#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 22:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

namespace BabylonJam
{
    internal class QuestionManager : MonoBehaviour
    {
        private static QuestionManager instance;

        public static QuestionManager Instance
        {
            get
            {
                return instance;
            }
        }

        private QuestionList list;
        private WordPool pool;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            list = DatabaseManager.Read<QuestionList>("QuestionList");
            pool = new WordPool();

            //gameObject.SetActive(false);
        }

        public void AskQuestion(int id)
        {
            Question question = list[id];

            AddWordsToBag(question.Words);
            SentenceBar.Instance.SetAnswer(question.Answer);
            gameObject.SetActive(true);
        }

        private void AddWordsToBag(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                Word word = pool.GetWord;
                word.Text = words[i];
                word.gameObject.SetActive(true);
                word.SetBagIndex(i);
                word.Move(WordBag.Instance.SlotPosition(i), WordBag.Instance.transform);
            }
        }
    }
}