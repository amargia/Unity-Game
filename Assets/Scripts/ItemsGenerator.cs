using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [Serializable]
    public struct ItemData
    {
        public Sprite itemSprite;
    }

    [SerializeField] private InventoryItems m_itemPrefab;
    [SerializeField] private List<ItemData> m_itemsData;
    [SerializeField] private RectTransform m_parent;

    private void Awake()
    {
        foreach (var l_itemData in m_itemsData)
        {
            var l_item = Instantiate(m_itemPrefab, m_parent);
            l_item.SetInfo(l_itemData.itemSprite);
        }
    }
}
