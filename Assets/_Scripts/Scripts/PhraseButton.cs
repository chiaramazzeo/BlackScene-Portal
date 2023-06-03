using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhraseButton : MonoBehaviour
{

public Animator animator = null;

public void InputTextIn() 
{
    animator.SetBool("ShareAccomplishment", true);
}

public void ShareInstruction() 
{
    animator.SetBool("ShareIn", true);
}

public void YourWill() 
{
    animator.SetBool("YourIn", true);
}

}



