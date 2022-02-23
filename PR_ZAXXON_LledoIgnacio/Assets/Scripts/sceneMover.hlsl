/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneMover : MonoBehaviour
{

}*/

//UNITY_SHADER_NO_UPGRADE
#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED
//#include "Assets/Scripts/GameFunctions.cs"

void Movement_float(float time, float size, out float Out)
{

    Out = (time*0.01) * (time*3) + (time*size);
}
#endif //MYHLSLINCLUDE_INCLUDED

