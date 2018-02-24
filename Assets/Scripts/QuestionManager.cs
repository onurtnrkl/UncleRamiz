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

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            list = DatabaseManager.Read<QuestionList>("QuestionList");
        }

        private Question GetQuestion(int id)
        {
            return list[id];
        }

        public void AskQuestion(int id)
        {
            //Open Question panel
            //Get data from database
            //draw question panels
            gameObject.SetActive(true);
        }
    }
}