using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Slider energyBar;

    [SerializeField] private int maxEnergy = 100;
    private float currentEnergy;
     
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyBar.value = maxEnergy;

        Application.targetFrameRate = 30;

        StartCoroutine(AddEnergy());
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

        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    IEnumerator AddEnergy()
    {
        while (true)
        {
            UseEnergy(-1);
            yield return new WaitForSeconds(2f);
        }
    }
}
