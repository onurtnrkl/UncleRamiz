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
    internal class DecisionManager : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Show()
        {
            animator.SetBool("IsOpen", true);

            StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            yield return new WaitForSeconds(5f);

            animator.SetBool("IsOpen", false);
        }
    }    
}