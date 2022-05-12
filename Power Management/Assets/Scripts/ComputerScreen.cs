using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{
    public GameObject computerScreen;
    public bool isEnabled;
    public EnergyManager _energyManager;

    public Material enabledComputerScreen;
    public Material disabledComputerScreen;

    void Start()
    {
        isEnabled = true;
    }

    void Update()
    {
        if (isEnabled)
        {
            //If the Computer is on it will consume Energy
            _energyManager.UseEnergy(0.07f);
            computerScreen.GetComponent<Renderer>().material = enabledComputerScreen;
        }
        else
        {
            //When it's off it does not consume energy
            isEnabled = false;
            computerScreen.GetComponent<Renderer>().material = disabledComputerScreen;
        }

        // For Debugging
        if (Input.GetKey(KeyCode.Q))
        {
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
}