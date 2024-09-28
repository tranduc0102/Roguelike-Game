public class EnemyDamageReceiver : DamageReceiver
{
    public int enemyIndex;
    protected override void LoadData()
    {
        maxHp = data.listEnemyData[enemyIndex].maxHp;
    }

    protected override void OnDead()
    {
        base.OnDead();
    }
}
