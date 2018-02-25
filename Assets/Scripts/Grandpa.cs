#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       23/02/2018 23:19

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace BabylonJam
{
    internal class Grandpa : MonoBehaviour, IPointerClickHandler
    {
        private static Grandpa instance;

        public static Grandpa Instance
        {
            get
            {
                return instance;
            }
        }

        public QuestionBubble Bubble;
        public bool IsBussy;
        private int step = 0;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            Bubble = GetComponentInChildren<QuestionBubble>();
        }

        public void NextStep()
        {
            step++;
            QuestManager.Instance.ResetContext();
            IsBussy = true;
            StartCoroutine(Ask());
        }

        private IEnumerator Ask()
        {
            yield return new WaitForSeconds(1f);

            Bubble.SetDialog(QuestManager.Instance.GetQuest(step).Question);
            Bubble.Show();
            QuestManager.Instance.AskQuestion(step);
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if(!IsBussy)
            {
                IsBussy = true;
                Bubble.SetDialog(QuestManager.Instance.GetQuest(step).Question);
                Bubble.Show();
                QuestManager.Instance.AskQuestion(step);
            }
        }
    }    
}