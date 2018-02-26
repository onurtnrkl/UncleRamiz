#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       23/02/2018 23:19

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using UnityEngine.EventSystems;

namespace BabylonJam
{
    internal class InformationObject : MonoBehaviour, IPointerClickHandler
    {
        public string information;
        public string audioName;

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if(!Grandpa.Instance.IsBussy)
            {
                Grandpa.Instance.IsBussy = true;
                SoundManager.PlayClip(Resources.Load<AudioClip>("Sounds/" + audioName));
                Grandpa.Instance.Bubble.SetDialog(information);
                Grandpa.Instance.Bubble.Show(information.Length / 5);
            }
        }
    }    
}