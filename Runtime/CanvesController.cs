using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FarrokhGames.Inventory
{
    [Serializable]
    public class CanvesController : MonoBehaviour
    {

        public List<Item> items, itemT;
        public Transform machine;

        public List<Item> speed;
        public List<Item> list;

        public List<string> truckX2;


        public float rpm,oldoldrpm , oldoldoldrpm = 20f;
        public float oldRpm = 20f;

       

        public float speedfloat = 5f;
        float oldspeedfloat;
        void Start()
        {
            oldoldrpm = rpm;
            oldoldoldrpm = oldRpm;
            oldspeedfloat = speedfloat;
            if (name.Contains("Rpm"))
            {
                rpm = 20; 
                oldRpm = rpm;
            }
            else
            {
                rpm = 0;
                oldRpm = rpm;
            }
            speed = new List<Item>();
            list = new List<Item>();
            items = new List<Item>();
            itemT = new List<Item>();

        }

        private void Update()
        {

            GetPostion();


        }

        public void GetPostion()
        {
           // RemoveNotDragged();
            int i = 1;

            foreach (var item in items)
            {
                if (!itemT.Contains(item))
                {
                    itemT.Add(item);
                    CalCulateRPM();
                }
                else
                {
                    CalCulateRPM();

                }

            }
            //while (items.Count > 0)
            //{
            //    //var item = GetMinimumItem();
            //    //items.Remove(item);

            //    if (list.Contains(item))
            //    {
            //        list.Remove(item);
            //        list.Add(item);

            //    }
            //    else
            //    {
            //        list.Add(item);
            //        OrdreList();

            //    }



            //}

        }


        void CalCulateRPM()
        {
            foreach (var item in itemT)
            {
                item.UsedInCalcul = false;
            }

              rpm = oldoldrpm;
              oldRpm = oldoldoldrpm;
            speedfloat = oldspeedfloat;
            foreach (var itemx in itemT)
            {

                var item = GetMinimumItem();
               // print(item._type);

                if (item == null) return;
                if (item._type.Equals(ItemType.X2))
                {
                    item.UsedInCalcul = true;
                }

                if (!item.UsedInCalcul)
                {
                    if (item._type.Equals(ItemType.Add2))
                    {
                        if (!item.UsedInCalcul)
                        {
                            rpm += 2 * (CheckCountX2Before(item) + 1);
                            oldRpm += 2 * (CheckCountX2Before(item) + 1);
                            speedfloat +=2 * (CheckCountX2Before(item) + 1);
                            item.UsedInCalcul = true;
                        }

                    }
                    else if (item._type.Equals(ItemType.Add1))
                    {
                        if (!item.UsedInCalcul)
                        {
                            rpm += 1 * (CheckCountX2Before(item) + 1);
                            oldRpm += 1 * (CheckCountX2Before(item) + 1);
                            speedfloat += 1 * (CheckCountX2Before(item) + 1);
                            item.UsedInCalcul = true;
                        }
                    }
                    else if (item._type.Equals(ItemType.Add3))
                    {
                        if (!item.UsedInCalcul)
                        {
                            rpm += 3 * (CheckCountX2Before(item) + 1);
                            oldRpm += 3 * (CheckCountX2Before(item) + 1);
                            speedfloat += 3 * (CheckCountX2Before(item) + 1);
                            item.UsedInCalcul = true;
                        }
                    }
                    else if (item._type.Equals(ItemType.Add4))
                    {
                        if (!item.UsedInCalcul)
                        {
                            rpm += 4 * (CheckCountX2Before(item) + 1);
                            oldRpm += 4 * (CheckCountX2Before(item) + 1);
                            speedfloat += 4 * (CheckCountX2Before(item) + 1);
                            item.UsedInCalcul = true;
                        }
                    }
                }

                
            }
            
           
        }


        public Item GetMinimumItem()
        {
            float min = float.MinValue;
            Item minItem = null;
            foreach (var item in itemT)
            {

                if (item.position.y >= min && !item.UsedInCalcul)
                {
                    minItem = item;
                    min = item.position.y;
                }


            }
            return minItem;
        }


        private void RemoveNotDragged()
        {
            foreach (var item in items.ToArray())
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
            foreach (var it in itemT)
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
            list.Clear();
            list = items.OrderBy(w => w.position.y).ToList();

        }
    }
}
