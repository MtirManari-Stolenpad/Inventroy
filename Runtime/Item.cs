using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarrokhGames.Inventory;


namespace FarrokhGames.Inventory
{
    public enum ItemType
    {
        Any,
        Add2,
        Add4,
        X2,
    }
    [Serializable]
    public class Item : MonoBehaviour
    {
        public List<Transform> slots;
        public bool dragged = false;
        public Vector2 position;
        public ItemType _type = ItemType.Any;
        public float rpm = 50f;
        private void Awake()
        {
            position = Vector2.zero;
            slots = new List<Transform>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            slots.Add(other.transform);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            slots.Remove(other.transform);
            dragged = true;
        }
    }
}
