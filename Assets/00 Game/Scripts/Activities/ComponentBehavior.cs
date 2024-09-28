using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadComponent();
    }

    protected virtual void Start()
    {
        LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        
    }
}
