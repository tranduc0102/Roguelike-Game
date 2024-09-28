
using System;
using UnityEngine;
using DG.Tweening;
public class EnemyHide : ComponentBehavior
{
    [SerializeField] private float timeHide;
    [SerializeField] private GameObject objHide;
    [SerializeField] private GameObject objActive;
    [SerializeField] private Collider2D _collider2D;
    public bool IsActive;

    protected void OnEnable()
    {
        IsActive = false;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _collider2D = GetComponent<Collider2D>();
        objActive = transform.GetChild(1).gameObject;
        objHide = transform.GetChild(0).gameObject;
        objHide.SetActive(true);
        objActive.SetActive(false);
        _collider2D.enabled = false;
       
    }

    public void HideEnemy() // Hàm này để ẩn quái thông báo cho người chơi vị trí quái sẽ Spawn
    {
        var originalScale = objHide.transform.localScale;
        var toScale = originalScale*1.5f;
       
        OnScale(objHide.transform,originalScale,toScale);
    }
    private void OnScale(Transform obj,Vector3 originalScale,Vector3 toScale)
    {
        // Hàm này dùng để chỉnh scale của gameObject Hide
        obj.DOScale(toScale, 0.5f)
            .SetEase(Ease.InOutSine)
            .OnComplete(() => {
                obj.DOScale(originalScale, 0.25f)
                    .SetEase(Ease.OutBounce)
                    .SetDelay(0.1f)
                    .OnComplete(()=> OnScale(obj, originalScale, toScale)); 
            })
            .SetLoops(5)
            .OnComplete(()=>OnActive());
    }
    private void OnActive() // Quái Xuất hiện
    {
        IsActive = true;
        objActive.SetActive(true);
        objHide.SetActive(false);
        _collider2D.enabled = true;
        
    }
}
