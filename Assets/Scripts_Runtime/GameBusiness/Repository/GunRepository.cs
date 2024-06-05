using System;
using System.Collections.Generic;


public class GunRespository {

    Dictionary<int, GunEntity> all;

    GunEntity[] temArray;

    public GunRespository() {
        all = new Dictionary<int, GunEntity>();
        temArray = new GunEntity[5];
    }

    public void Add(GunEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(GunEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out GunEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new GunEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out GunEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<GunEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}