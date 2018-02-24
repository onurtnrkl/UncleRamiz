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
        private readonly List<GameObject> words;
        private readonly int size;

        public WordPool(int size)
        {
            this.size = size;
            words = new List<GameObject>();
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Word");

            for (int i = 0; i < size; i++)
            {
                GameObject word = Object.Instantiate(prefab);
                word.SetActive(false);
                words.Add(word);
            }
        }

        public void Spawn(Vector2 position)
        {
            GameObject word = GetWord;
            word.transform.position = position;
            word.SetActive(true);
        }

        private GameObject GetWord
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    GameObject word = words[i];

                    if (!word.activeInHierarchy)
                        return word;
                }

                return null;
            }
        }
    }
}