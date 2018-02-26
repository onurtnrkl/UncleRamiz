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
    internal class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

        private QuestList list;
        private WordPool pool;
        private Animator animator;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            GameObject canvas = Instantiate(Resources.Load<GameObject>("Prefabs/Canvas"));
            canvas.gameObject.SetActive(true);
            animator = canvas.transform.Find("AnswerContext").GetComponent<Animator>();
            SoundManager.Create();
            list = DatabaseManager.Read<QuestList>("QuestList");
            pool = new WordPool();
            ResetContext();
        }

        public void ResetContext()
        {
            animator.SetBool("IsOpen", false);
            pool.Reset();
        }

        public Quest GetQuest(int id)
        {
            return list[id];
        }

        public void AskQuestion(int id)
        {
            Quest quest = list[id];
            AddWordsToBag(quest.Words);
            SentenceBar.Instance.SetAnswer(quest.Answer);
            animator.SetBool("IsOpen", true);
        }

        private void AddWordsToBag(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                Word word = pool.GetWord;
                word.Text = words[i];
                word.gameObject.SetActive(true);
                word.SetBagIndex(i);
                word.transform.SetParent(WordBag.Instance.transform);
                word.transform.localScale = Vector2.one;
                word.transform.position = WordBag.Instance.SlotPosition(i);
            }
        }
    }
}