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
        public Text text;

        public List<string> drillers;
        public List<float> speed;
        void Start()
        {
            drillers = new List<string>();
            speed = new List<float>();
            items = new List<Item>();
            text.text = "";
        }

        public void GetPostion()
        {
            RemoveNotDragged();
            OrdreList();

            int i = 1;
            foreach (var item in itemT)
            {
                bool onlyonce = false;

                if (!item._type.Equals(ItemType.X2) )
                {
                    if (CheckCountX2Before(item) >0 && !onlyonce)
                    {
                        item.rpm *= CheckCountX2Before(item) *2;
                        onlyonce = true;
                    }
                    drillers.Add(item._type.ToString());
                    speed.Add(item.rpm);
                    text.text += item.position.y.ToString() + " : " + item._type.ToString() + "RPM : " + item.rpm + "\n";
                }
            }

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
            foreach(var it in items)
            {
                if (it._type.Equals(ItemType.X2) && it.dragged && it.position.y > item.position.y)
                {
                    count++;
                    print(it.gameObject.name);
                }
            }
            return count;
        }


        void OrdreList()
        {
            itemT = items.OrderBy(w => w.position.y).ToList();


        }

     
        static int SortByScore(Vector2 p1, Vector2 p2)
        {
            return p1.y.CompareTo(p2.y);
        }

    }
}
