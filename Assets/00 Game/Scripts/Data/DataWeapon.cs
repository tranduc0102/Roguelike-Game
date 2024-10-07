using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataWeapon", menuName ="Data/DataWeapon")]
public class DataWeapon : ScriptableObject
{
    public List<Transform> weapons;
}