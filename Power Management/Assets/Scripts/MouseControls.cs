using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
    public Light lampLight;
    public ComputerScreen ComputerScreen;
    public RoomLights RoomLight;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    print(hit.transform.gameObject);
                    if (hit.collider.gameObject.name == "Floor Lamp")
                    {
                        lampLight.turnOff();
                    }
                }

                if (hit.collider.gameObject.name == "Computer Setup")
                {
                    print(hit.transform.gameObject);
                    ComputerScreen.isEnabled = false;
                }
                
                if (hit.transform != null)
                {
                    print(hit.transform.gameObject);
                    if (hit.collider.gameObject.name == "LightSwitch")
                    {
                        RoomLight.turnOff();
                    }
                }
            }
        }
    }
}
