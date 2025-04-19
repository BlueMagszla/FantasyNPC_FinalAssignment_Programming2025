/* Script for shade triggers.
 * 
 * Script handles if the zombie has entered shade. Sets booleans for when they enter/exit.
 * 
 * Magdalena Szlapczynski
 *  Last Modified: Apr.19, 2025
 */

using System.Collections;
using System.Collections.Generic;
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
