using System;
using UnityEngine;

public class GunEntity : MonoBehaviour {

    public int id;

    [SerializeField] public Transform bulletPos;


    public float msBetweenShots; 

    public float muzzleVelocity;

    public float nextShotTime;



    public GunEntity() { }


    public void Ctor(float msBetweenShots, float muzzleVelocity) { 
        this.msBetweenShots = msBetweenShots;
        this.muzzleVelocity = muzzleVelocity;
    }

}