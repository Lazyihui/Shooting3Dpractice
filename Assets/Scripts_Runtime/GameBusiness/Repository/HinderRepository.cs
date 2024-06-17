using System;
using System.Collections.Generic;
using UnityEngine;


public class HinderRepository {

    Dictionary<int, HinderEntity> all;

    HinderEntity[] temArray;

    public HinderRepository() {
        all = new Dictionary<int, HinderEntity>();
        temArray = new HinderEntity[10];
    }

    public void Add(HinderEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(HinderEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out HinderEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new HinderEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out HinderEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<HinderEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }
}