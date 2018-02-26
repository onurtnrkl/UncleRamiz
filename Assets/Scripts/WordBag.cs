#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       23/02/2018 23:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

namespace BabylonJam
{
    internal class WordBag : MonoBehaviour
    {
        private static WordBag instance;

        public static WordBag Instance
        {
            get
            {
                return instance;
            }
        }

        [SerializeField]private Transform[] slots;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
        }

        public Vector2 SlotPosition(int index)
        {
            return slots[index].transform.position;
        }
    }
}