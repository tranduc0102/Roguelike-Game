using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float damage;
    [SerializeField] protected float arangeAttack;
    [SerializeField] protected float speed = 5f;

    public void Init(PlayerData data)
    {
        hp = data.basicHp;
        damage = data.basicDamage;
        speed = data.basicSpeed;
    }
}