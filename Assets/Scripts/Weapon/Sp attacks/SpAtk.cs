using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpAtk : MonoBehaviour
{
    
    public float maxCharge = 1;

    public void RelaySpAtkActivation()
    {
        BroadcastMessage("ActivateSpAtk");
    }
}
