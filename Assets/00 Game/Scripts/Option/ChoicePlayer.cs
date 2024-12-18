using UnityEngine;


public class ChoicePlayer : OptionBase
{
    private PlayerData playerData;
    private void OnEnable()
    {
        chooseBtn.onClick.AddListener(Choice);
    }
    public void Init(PlayerData data)
    {
        optionName.text = data.playerName;
        image.GetComponentInChildren<Animator>().runtimeAnimatorController = data.animator;
        description.text = $"Damage: {data.basicDamage} \n HP: {data.basicHp} \n Speed: {data.basicSpeed}";
        playerData = data;
    }
    protected virtual void Choice()
    {
        LoadScenceGame();
        HireChooseOption();
    }
    private void LoadScenceGame()
    {
        DataSelect.Instance.Player = playerData;
        GameManager.Instance.ShowWeaponSelectionPanel();
    }

    protected virtual void HireChooseOption()
    {
        GameManager.Instance.HidePlayerSelectionPanel();
    }
}
