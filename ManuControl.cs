using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;

public class ManuControl : MonoBehaviour
{
    public GameObject ManuObject;
    public GameObject ParkingSlot;
    private bool ControlManuButton = false;
    private bool ControlParkingLock = false;
    // Start is called before the first frame update
    public GameObject TTPbuttonChangeText;
    public GameObject LUbuttonChangeText;
    private ButtonConfigHelper TTPChangeText;
    private ButtonConfigHelper LUChangeText;
    private TapToPlace parking;
    private bool button = false;
    void Start()
    {
        //parking = ParkingSlot.GetComponent<TapToPlace>();
        TTPChangeText = TTPbuttonChangeText.GetComponent<ButtonConfigHelper>();
        TTPChangeText.MainLabelText = "Tap To Place Off";
        LUChangeText = LUbuttonChangeText.GetComponent<ButtonConfigHelper>();
        LUChangeText.MainLabelText = "Scene Unlocked";
        //parking.enabled = false;
    }
    public void buttonChange()
    {
        button = !button;
        eventHappend();
    }
    public void eventHappend()
    {
        if (button == true)
        {
            parking.enabled = true;
            TTPChangeText.MainLabelText = "Tap To Place On";
        }
        else
        {
            parking.enabled = false;
            TTPChangeText.MainLabelText = "Tap To Place Off";
        }

    }
    public void ControlManu()
    {
        ControlManuButton = !ControlManuButton;
        if (ControlManuButton)
        {
            ManuObject.SetActive(true);
        }
        else
        {
            ManuObject.SetActive(false);
        }

    }
    public void LockScene()
    {
        ControlParkingLock = !ControlParkingLock;
        if (ControlParkingLock)
        {
            GameObject.Find("Parking(Clone)").GetComponent<BoxCollider>().enabled=false;
            LUChangeText.MainLabelText = "Scene locked";
        }
        else
        {
            GameObject.Find("Parking(Clone)").GetComponent<BoxCollider>().enabled = true;
            LUChangeText.MainLabelText = "Scene Unlocked";
        }
        

    }
  
}
