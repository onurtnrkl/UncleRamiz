#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       23/02/2018 23:19

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BabylonJam
{
    internal class ClickableObject : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //SpeechBubbleManager.Open(GetComponent<RectTransform>(), "Who? Who? Are you talking to me?");
            QuestionManager.Instance.AskQuestion(0);
        }
    }    
}