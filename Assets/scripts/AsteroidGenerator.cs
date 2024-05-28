﻿#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    //model zawierajacy trzy kostki
    GameObject model;
    //wylosowana rotacja/s
    Vector3 rotation = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        //przypisuje do zmiennej model obiekt-pojemnik zawierajacy kostki bedace czescia modelu asteroidy
        model = transform.Find("Model").gameObject;
        //przygotuj generator liczb losowych
        //Random r = new Random();
        //nie robimy tego bo unity.random jest statycznie w przeciwienstwie do system.random

        //literuj przez czêœci modelu
        foreach (Transform cube in model.transform)
        {
            //uzyj wbudowanego random.rotation
            cube.rotation = Random.rotation;

            //losowa liczba
            float scale = Random.Range(0.9f, 1.1f);

            //przeskaluj
            cube.localScale = new Vector3(scale, scale, scale);
        }

        //wylosuj jednorazowo rotacje/s naszej asteroidy
        rotation.x = Random.value;
        rotation.y = Random.value;
        rotation.z = Random.value;
        rotation *= Random.Range(10, 20);



    }

    // Update is called once per frame
    void Update()
    {
        //obróæ asteroidê w wyznaczonym kierunku
        model.transform.Rotate(rotation * Time.deltaTime);
    }
}