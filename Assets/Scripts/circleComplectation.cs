using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "circleInfo", menuName = "Gameplay/ New circleInfo")]
public class circleComplectation: ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite[] _parts;

    public Sprite sprite => _sprite;
    public Sprite[] parts => _parts;
}
