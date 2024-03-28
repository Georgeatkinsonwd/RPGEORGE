using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour 
{

    public Image icon;
    public TextMeshProUGUI textMeshPro;

    public void Display(string name, Sprite itemSprite)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = name;
        }
        
        if (icon != null)
        {
            icon.sprite = itemSprite;
        }
        
    }

  
}


// refactoring CTRL R R renames everything and where it's referenced. works for variables, classes and methods