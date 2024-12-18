using UnityEngine;

public class MeleeEnemyAttack : EnemyAttack
{
    [SerializeField] protected MeleeEnemySendDamage meleeEnemySendDamage;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadMeleeEnemySendDamage();
    }

    protected virtual void LoadMeleeEnemySendDamage()
    {
        if (meleeEnemySendDamage != null) return;
        meleeEnemySendDamage = transform.GetComponentInChildren<MeleeEnemySendDamage>();
    }

    protected override void Attacking()
    {
        AudioManager.Instance.PlayImpactBodySound();
        meleeEnemySendDamage.SendDamage(enemyCtrl.Player);
    }
}
