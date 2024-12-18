using System;
using DG.Tweening;
using UnityEngine;

public class EnemyAnim : ComponentBehavior
{
    [SerializeField] protected Vector3 prePosition;
    [SerializeField] protected Vector3 curPosition;
    private readonly float _scaleY = 1.2f;  // chỉnh scale.y lên 1.2
    private readonly float _bounceDuration = 0.5f;  // Thời gian nhún trong mỗi chu kỳ
    private readonly int _bounceLoops = -1; // vòng lặp vô tận
    private Tween _bounceTween;

    protected override void Start()
    {
        base.Start();
        ChangeScale();
        prePosition = transform.parent.parent.position;
    }

    private void OnEnable()
    {
        // Chỉ khởi tạo lại tween nếu tween đã bị hủy
        if (_bounceTween == null || !_bounceTween.IsActive())
        {
            ChangeScale();
        }
    }

    private void OnDisable()
    {
        // Kiểm tra nếu _bounceTween còn hoạt động và dừng nó khi không cần thiết
        if (_bounceTween != null && _bounceTween.IsActive())
        {
            _bounceTween.Kill();
        }
    }

    private void OnDestroy()
    {
        _bounceTween.Kill();
    }

    protected void RotateAnim()
    {
        curPosition = transform.parent.parent.position;
        if (curPosition.x == prePosition.x) return;
        float angle = 0;
        if (curPosition.x < prePosition.x) angle = 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        prePosition = curPosition;
    }

    protected void ChangeScale()
    {
        // Nếu tween đã tồn tại, hãy hủy nó trước khi tạo tween mới
        if (_bounceTween != null && _bounceTween.IsActive())
        {
            _bounceTween.Kill();
        }

        _bounceTween = transform.DOScaleY(Vector3.one.y * _scaleY, _bounceDuration)
            .SetLoops(_bounceLoops, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    private void Update()
    {
        RotateAnim();
    }
}
