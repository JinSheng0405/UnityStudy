using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManage : MonoBehaviour
{
    // Start is called before the first frame update
    public void StopFollow()
    {
        GameObject.Find("CM vcam2").GetComponent<CarFollow>().enabled =  false;
    } 
}
