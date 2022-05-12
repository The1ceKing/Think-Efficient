using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLights : MonoBehaviour
{
    public Light lightsource;
    public static bool isEnabled;
    public EnergyManager _energyManager;

    void Start()
    {
        isEnabled = true;
    }
    
    void Update()
    {
        if (isEnabled)
        {
            // If the Light Source is being used it will consume energy
            _energyManager.UseEnergy(0.01f);
            lightsource.enabled = true;
        }
        else
        {
            //If the Light Source is not being used it will not consume energy
            lightsource.enabled = false;
            isEnabled = false;
        }
        
        // For Debugging
        if (Input.GetKey(KeyCode.E))
        {
            lightsource.enabled = false;
            isEnabled = false;
        }
    }

    //Allows for the NPC to turn on the Computer and "use" it
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEnabled = true;
        }
    }

    public void turnOff()
    {
        isEnabled = false;
    }
}


