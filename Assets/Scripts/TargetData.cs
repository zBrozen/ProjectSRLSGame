using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData : MonoBehaviour
{
    public TargetList targetType;
    public int currentHP;
}

public enum TargetList{
    obstacle,
    bullet,
    warrior,
    shooter
}