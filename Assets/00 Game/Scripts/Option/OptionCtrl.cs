using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionCtrl : ComponentBehavior
{
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI optionName;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected Button chooseBtn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadImage();
        LoadOptionName();
        LoadDescription();
        LoadChooseBtn();
    }

    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.Find("ImgAndName").Find("Image").GetComponent<Image>();
    }

    protected virtual void LoadOptionName()
    {
        if(optionName != null) return;
        optionName = transform.Find("ImgAndName").Find("Name").GetComponent<TextMeshProUGUI>();
    }

    protected virtual void LoadDescription()
    {
        if (description != null) return;
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    protected virtual void LoadChooseBtn()
    {
        if (chooseBtn != null) return;
        chooseBtn = transform.Find("Button").GetComponent<Button>();
    }

    public void Init(Sprite _image, string _optionName, string _description)
    {
        if (_image != null) image.sprite = _image;
        if (_optionName != String.Empty) optionName.text = _optionName;
        else optionName.text = "";
        if (_description != String.Empty) description.text = _description;
        else description.text = "";
    }
}
