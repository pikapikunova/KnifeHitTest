using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameInfo", menuName = "Gameplay/ New gameInfo")]
public class gameInfo : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private int _score;
    [SerializeField] private int _maxScore;
    [SerializeField] private int _heartScore;

    public int level => _level;
    public int score => _score;
    public int maxScore => _maxScore;
    public int heartScore => _heartScore;
}