using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    [SerializeField] private Image m_itemImage;
    public void SetInfo(Sprite sprite)
    {
        m_itemImage.sprite = sprite;
    }
}
