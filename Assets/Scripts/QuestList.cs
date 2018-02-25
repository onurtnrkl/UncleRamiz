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
    internal class QuestList
    {
        [SerializeField]
        private List<Quest> list;

        public QuestList()
        {
            list = new List<Quest>
            {
                new Quest(),
                new Quest()
            };
        }

        public Quest this[int index]
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