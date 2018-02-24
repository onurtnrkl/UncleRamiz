#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 22:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BabylonJam
{
    [Serializable]
    internal class QuestionList
    {
        [SerializeField]
        private List<Question> list;

        public QuestionList()
        {
            list = new List<Question>
            {
                new Question(),
                new Question()
            };
        }

        public Question this[int index]
        {
            get
            {
                return list[index];
            }

            set
            {
                list[index] = value;
            }
        }
    }
}