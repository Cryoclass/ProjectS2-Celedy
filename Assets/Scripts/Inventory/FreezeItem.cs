using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class FreezeItem : MonoBehaviour
{
    private Transform player;

    private float CdStun;
    public float TimeFreeze;
    public float zoneFreeze;

    private bool IsUsed;
    private float Defspeed;
    private bool DefShootCd;
    

    private SkeletonIA _skeletonIa;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _skeletonIa = GameObject.FindGameObjectWithTag("Enemy").GetComponent<SkeletonIA>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Defspeed = _skeletonIa.speed;
        DefShootCd = _skeletonIa.CanShoot;
    }


    void Update()
    {
        if (IsUsed)
        {
            CdStun -= Time.deltaTime;
            if (CdStun < 0)
            {
                IsUsed = false;
                _skeletonIa.speed = Defspeed;
                _skeletonIa.CanShoot = DefShootCd;
            }
        }
    }


    public void Use()
    {
        IsUsed = true;
        foreach (var enemies in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            _skeletonIa.speed = 0;
            _skeletonIa.CanShoot = false;
        }

        CdStun = TimeFreeze;
        
        
    }
}
