using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{

public Animator animatorIF, animatorCN, animatorInsta, animatorARB, animatorShare, animatorYA;

public void Sendanimation() 
{
    animatorIF.SetBool("MessageSent", true);
    animatorCN.SetBool("CongIN", true);
    animatorARB.SetBool("ARButtonOn", true);
    animatorShare.SetBool("ShareIn", false);
    animatorYA.SetBool("YourAccomplishmentIn", false);
    animatorInsta.SetBool("InstaButtonOn", true);


}

}



