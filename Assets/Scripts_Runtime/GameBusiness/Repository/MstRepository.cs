using System;
using System.Collections.Generic;


public class MstRespository {

    Dictionary<int, MstEntity> all;

    MstEntity[] temArray;

    public MstRespository() {
        all = new Dictionary<int, MstEntity>();
        temArray = new MstEntity[5];
    }

    public void Add(MstEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(MstEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out MstEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new MstEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out MstEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<MstEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}