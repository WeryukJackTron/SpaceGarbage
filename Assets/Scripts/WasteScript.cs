using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteScript : MonoBehaviour
{
    [System.Serializable]
    public enum WasteTypes { Compost = 0, Paper = 1, Plastic = 2, Metal = 3}
    public WasteTypes type;
}
