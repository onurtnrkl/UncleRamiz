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

        private Vector2[] slots;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            CreateSlots();
        }

        private void CreateSlots()
        {
            slots = new Vector2[9];

            int index = 0;
            float x = 200;
            float y = 400;

            for (int i = 0; i < 3; i++)
            {
                y = 400;

                for (int j = 0; j < 3; j++)
                {
                    Vector2 position = new Vector2(x, y);
                    slots[index] = position;

                    index++;
                     y -= 150;
                }

                x += 340;
            }
        }

        public Vector2 SlotPosition(int index)
        {
            return slots[index];
        }
    }
}