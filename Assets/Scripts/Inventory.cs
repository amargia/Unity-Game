using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public struct ItemData
    {
        public int id;
        public string name;
        public string description;

        public override string ToString()
        {
            string l_itemString = string.Empty;
            l_itemString += "Name: " + name + "\n" + "Description: " + description;
            return l_itemString;
        }
    }

    [SerializeField] private List<Item> m_itemsList;
    private Dictionary<string, ItemData> m_itemsDictionary = new Dictionary<string, ItemData>();

    private void PrintItemInfo()
    {
        if (m_itemsDictionary.TryGetValue("bow", out ItemData m_bowData))
        {
            Debug.Log(m_bowData);
        }
    }

    private void RemoveItemInfo()
    {
        m_itemsDictionary.Remove("chocolate");
        Debug.Log("Item Chocolate successfully removed");
        //Pantalla que diga "They took my Golden Bar!"
    }

    private void Awake()
    {
        ItemData m_chocolateData = new ItemData()
        {
            id = 0,
            name = "Chocolate",
            description = "Most important thing in the universe"
        };

        ItemData m_bowData = new ItemData()
        {
            id = 1,
            name = "Bow",
            description = "I can use this to kill my enemies who don't want me to get my chocolate! ... I need arrows for this though"
        };

        ItemData m_arrowData = new ItemData()
        {
            id = 2,
            name = "Arrow",
            description = "Simple arrow used with a bow to kill enemies. It doesn't do much damage, but it gets the job done."
        };

        m_itemsDictionary.Add("chocolate", m_chocolateData);
        m_itemsDictionary.Add("bow", m_bowData);
        m_itemsDictionary.Add("arrow", m_arrowData);

        Debug.Log(m_arrowData);
        PrintItemInfo();
        RemoveItemInfo();

        //m_itemsList = new List<Item>();
        Debug.Log(m_itemsList.Count);
    }
}
