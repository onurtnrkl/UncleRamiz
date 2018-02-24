#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 16:26

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

namespace BabylonJam
{
    internal struct BagSlot
    {
        private Vector2 position;

        public bool IsEmpty;

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public BagSlot(Vector2 position)
        {
            this.position = position;
            IsEmpty = true;
        }
    }
}