using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhraseButton : MonoBehaviour
{

public Animator animatorIT, animatorSI, animatorYW;

public void AllAnimations() 
{
    animatorIT.SetBool("InputText", true);
    animatorSI.SetBool("ShareIn", true);
    animatorYW.SetBool("YourAccomplishmentIn", true);
}

}



