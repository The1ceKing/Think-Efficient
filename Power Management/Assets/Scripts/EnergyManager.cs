using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Slider energyBar;

    [SerializeField] private int maxEnergy = 1000;
    private float currentEnergy;
     
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyBar.value = maxEnergy;
    }

    public void UseEnergy(float amount)
    {
        
        if(currentEnergy - amount > 0)
        {
            //Consume Energy
            currentEnergy -= amount;
            energyBar.value = currentEnergy;
        }
        else
        {
            //If the Energy hits zero then you lose
            print("You used all your energy!");
        }
}
}
