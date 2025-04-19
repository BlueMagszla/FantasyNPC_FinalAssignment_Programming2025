//ms

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VillageTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZombieController>() != null)
        {
            print("Enter Village");
            other.gameObject.GetComponent<ZombieController>().BBref.GetVariable("isInVillage", typeof(bool)).value = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ZombieController>() != null)
        {
            print("Exit Village");
            other.gameObject.GetComponent<ZombieController>().BBref.GetVariable("isInVillage", typeof(bool)).value = false;


        }
    }
}
