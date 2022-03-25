using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace FarrokhGames.Inventory
{
    [Serializable]
    public class CanvesController : MonoBehaviour
    {

        public List<Item> items, itemT;
        public Transform machine;

        public List<string> drillers;
        public List<float> speed;
        public List<string> truckX2;

        void Start()
        {
            drillers = new List<string>();
            speed = new List<float>();
            items = new List<Item>();
            itemT = new List<Item>();

        }

        public void GetPostion()
        {
            RemoveNotDragged();
            int i = 1;

            foreach (var item in items)
            {
                itemT.Add(item);
            }
            while (items.Count > 0)
            {
                var item = GetMinimumItem();
                items.Remove(item);

                if (!item._type.Equals(ItemType.X2))
                {
                    bool onlyonce = false;
                    drillers.Add(item._type.ToString() + "|" + item.rpm);
                    speed.Add(item.rpm);
                }
                else
                {
                    truckX2.Add(item._type.ToString());
                }

            }

        }


        public Item GetMinimumItem()
        {
            float min = float.MinValue;
            Item minItem = null;
            foreach (var item in items)
            {

                if (item.position.y >= min)
                {
                    minItem = item;
                    min = item.position.y;
                }


            }
            return minItem;
        }


        private void RemoveNotDragged()
        {
            foreach(var item in items.ToArray())
            {
                if (!item.dragged)
                {
                    items.Remove(item);
                }
            }
        }

        int CheckCountX2Before(Item item)
        {
            int count = 0;
            foreach(var it in itemT)
            {
                if (it._type.Equals(ItemType.X2) && it.dragged && it.position.y > item.position.y)
                {
                    count++;
                }
            }
            return count;
        }


        void OrdreList()
        {
            itemT.Clear();
            itemT = items.OrderBy(w => w.position.y).ToList();

        }      
    }
}
