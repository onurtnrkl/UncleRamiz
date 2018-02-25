#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 22:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BabylonJam
{
    internal class WordPool
    {
        private readonly List<Word> words;

        public WordPool()
        {
            words = new List<Word>();
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Word");

            for (int i = 0; i < 9; i++)
            {
                Word word = Object.Instantiate(prefab).GetComponent<Word>();
                word.gameObject.SetActive(false);
                words.Add(word);
            }
        }

        public Word GetWord
        {
            get
            {
                for (int i = 0; i < 9; i++)
                {
                    Word word = words[i];

                    if (!word.gameObject.activeInHierarchy)
                        return word;                       
                }

                return null;
            }
        }
    }
}