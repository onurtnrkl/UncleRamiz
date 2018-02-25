#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       23/02/2018 23:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BabylonJam
{
    internal class QuestionBubble : MonoBehaviour
    {
        private Animator animator;
        private Text text;
        private string dialog;
        private StringBuilder dialogText;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            text = GetComponentInChildren<Text>();
            dialogText = new StringBuilder();
        }

        public void SetPosition(RectTransform rect)
        {
            float x = rect.position.x;
            float y = rect.position.y + rect.sizeDelta.y / 2 + 20;

            transform.position = new Vector2(x, y);
        }

        public void SetDialog(string dialog)
        {
            this.dialog = dialog;
            dialogText.Length = 0;
        }

        private IEnumerator StartSpeech()
        {
            while(true)
            {
                dialogText.Append(dialog[dialogText.Length]);
                text.text = dialogText.ToString();

                if (dialogText.Length < dialog.Length)
                    yield return new WaitForSeconds(0.1f);
                else
                    break;
            }
        }

        public void Show()
        {
            animator.SetBool("IsOpen", true);

            StartCoroutine(StartSpeech());
        }

        public void Hide()
        {
            animator.SetBool("IsOpen", false);
        }
    }    
}