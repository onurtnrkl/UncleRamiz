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
        public string[] Words;

        public Question()
        {
            Words = new string[9];
            Answer = new string[3];

            Answer[0] = "Who";
            Answer[1] = "are";
            Answer[2] = "you";

            Words[0] = "is";
            Words[1] = "Why";
            Words[2] = "Who";
            Words[3] = "My";
            Words[4] = "are";
            Words[5] = "they";
            Words[6] = "our";
            Words[7] = "am";
            Words[8] = "you";
        }
    }
}