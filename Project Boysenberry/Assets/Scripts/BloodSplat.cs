using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplat : MonoBehaviour {

    public GameObject[] bloodSplats;
    private Transform position;

    void Start () {
        position = gameObject.transform;
        GameObject bloodSplat = bloodSplats[Random.Range(0, bloodSplats.Length)];
        Instantiate(bloodSplat,position);
    }
}
