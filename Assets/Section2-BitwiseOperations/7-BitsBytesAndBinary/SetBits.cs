using System;
using UnityEngine;

namespace Lecture_7
{
    public class SetBits : MonoBehaviour
    {
        int bSequence = 8 + 1 + 2; //This will print 1011
        //What will this give? = 8 + 1 + 2 + 64
        //Remember, each bit is a power of two so and is writen right to left
        //So it will print 1001011

        //Convert an int to its binary value
        void Start()
        {
            Debug.Log(Convert.ToString(bSequence, 2));
        }
    }
}