using System;
using UnityEngine;

public static class Common {


    public static void RandomArray<T>(T[] arr) {
     
        for (int i = 0; i < arr.Length; i++) {
            int randomIndex = UnityEngine.Random.Range(0, arr.Length);
            T temp = arr[i];
            arr[i] = arr[randomIndex];
            arr[randomIndex] = temp;
        }

    }
}