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
        private Transform poolObject;

        public WordPool()
        {
            words = new List<Word>();
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Word");
            poolObject = new GameObject("Pool").transform;

            for (int i = 0; i < 9; i++)
            {
                Word word = Object.Instantiate(prefab, poolObject).GetComponent<Word>();
                word.gameObject.SetActive(false);
                words.Add(word);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < words.Count; i++)
            {
                Debug.Log(i + " reseted.");
                words[i].gameObject.SetActive(false);
                words[i].transform.SetParent(poolObject);
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