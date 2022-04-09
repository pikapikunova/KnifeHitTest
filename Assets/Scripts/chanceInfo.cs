using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "chanceInfo", menuName = "Gameplay/ New chanceInfo")]
public class chanceInfo : ScriptableObject
{
    [SerializeField] private int _chan;

    public int chan => _chan;

}
