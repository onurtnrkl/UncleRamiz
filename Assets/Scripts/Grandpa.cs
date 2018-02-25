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
        public int Step = 0;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            Bubble = GetComponentInChildren<QuestionBubble>();
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if(!IsBussy)
            {
                IsBussy = true;
                Bubble.SetDialog(QuestManager.Instance.GetQuest(Step).Question);
                Bubble.Show();
                QuestManager.Instance.AskQuestion(Step);
            }
        }
    }    
}