using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBehavior : MonoBehaviour
{
    /// <summary>
    /// Các script muốn tự động load dữ liệu khi kéo vào có thể kế thừa từ scrip này
    /// </summary>
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
