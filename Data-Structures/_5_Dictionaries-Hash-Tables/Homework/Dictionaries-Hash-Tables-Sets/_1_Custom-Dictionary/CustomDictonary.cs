﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomDictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    public const int InitialCapacity = 16;
    public const float LoadFactor = 0.75f;

    private LinkedList<TKey> orderedElements;
    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    public CustomDictionary(int capacity = InitialCapacity)
    {
        this.orderedElements = new LinkedList<TKey>();
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }

    public int Count { get; private set; }

    public int Capacity { get { return this.slots.Length; } }

    public void Add(TKey key, TValue value)
    {
        this.GrowIfNeeded();
        int slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }
        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists: " + key);
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.orderedElements.AddLast(key);
        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        this.GrowIfNeeded();
        int slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }
        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                return false;
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.orderedElements.AddLast(key);
        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        var foundElement = this.Find(key);
        if (foundElement == null)
        {
            throw new KeyNotFoundException("Specified key was not found in the hash table!");
        }

        return foundElement.Value;
    }

    public TValue this[TKey key]
    {
        get { return this.Get(key); }
        set { this.AddOrReplace(key, value); }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var foundElement = this.Find(key);
        if (foundElement != null)
        {
            value = foundElement.Value;
            return true;
        }

        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slotNumber = this.FindSlotNumber(key);
        var elements = this.slots[slotNumber];
        if (elements != null)
        {
            return elements.FirstOrDefault(element => element.Key.Equals(key));
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        return this.Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        var slotNumber = this.FindSlotNumber(key);
        var elements = this.slots[slotNumber];
        if (elements != null)
        {
            var currentElement = elements.First;
            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    this.orderedElements.Remove(currentElement.Value.Key);
                    elements.Remove(currentElement);
                    this.Count--;
                    return true;
                }

                currentElement = currentElement.Next;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.orderedElements = new LinkedList<TKey>();
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get { return this.Select(element => element.Key); }
    }

    public IEnumerable<TValue> Values
    {
        get { return this.Select(element => element.Value); }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var key in this.orderedElements)
        {
            yield return this.Find(key);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void GrowIfNeeded()
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }
    }

    private void Grow()
    {
        var newHashTable = new CustomDictionary<TKey, TValue>(this.Capacity * 2);
        foreach (var element in this)
        {
            newHashTable.Add(element.Key, element.Value);
        }

        this.slots = newHashTable.slots;
        this.Count = newHashTable.Count;
    }

    private int FindSlotNumber(TKey key)
    {
        var slotNumber = Math.Abs(key.GetHashCode()) % this.slots.Length;
        return slotNumber;
    }
}
