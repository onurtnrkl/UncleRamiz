#region License
/*================================================================
Product:    BabylonJam
Developer:  Onur Tanrıkulu
Date:       24/02/2018 22:56

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System;

namespace BabylonJam
{
    [Serializable]
    internal class Question
    {
        public string[] Answer;
        public string[] Sentences;

        public Question()
        {
            Sentences = new string[9];
            Answer = new string[3];

            Answer[0] = "Who";
            Answer[1] = "are";
            Answer[2] = "you";

            Sentences[0] = "is";
            Sentences[1] = "Why";
            Sentences[2] = "Who";
            Sentences[3] = "My";
            Sentences[4] = "are";
            Sentences[5] = "they";
            Sentences[6] = "our";
            Sentences[7] = "am";
            Sentences[8] = "you";
        }
    }
}