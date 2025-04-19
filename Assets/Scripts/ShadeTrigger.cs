//ms

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadeTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZombieController>() != null)
        {
            print("Enter Shade");
            other.gameObject.GetComponent<ZombieController>().BBref.GetVariable("isInShade", typeof(bool)).value = true;
          
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ZombieController>() != null)
        {
            print("Exit Shade");
            other.gameObject.GetComponent<ZombieController>().BBref.GetVariable("isInShade", typeof(bool)).value = false;
           

        }
    }
}
