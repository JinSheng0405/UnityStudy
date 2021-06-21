using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
public class ControlTapToPlace : MonoBehaviour
{
    public GameObject buttonChangeText;
    private ButtonConfigHelper ChangeText;
    private TapToPlace parking;
    private bool button = false;
    void Start()
    {
        parking = GetComponent<TapToPlace>();
        ChangeText = buttonChangeText.GetComponent<ButtonConfigHelper>();
        ChangeText.MainLabelText = "Tap To Place Off";
        parking.enabled = false;
    }

    // Update is called once per frame
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
            ChangeText.MainLabelText = "Tap To Place On";
        }
        else
        {
            parking.enabled = false;
            ChangeText.MainLabelText = "Tap To Place Off";
        }

    }

}
