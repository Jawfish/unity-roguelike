using System;
using Actors;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AbilityManager abilityManager;
    [SerializeField] private float timeScale;

    public float TimeScale
    {
        get => timeScale;
        set => timeScale = value;
    }


    private void Start()
    {
        GameObject p = Instantiate(player);
        AbilityManager am = Instantiate(abilityManager);
        p.GetComponent<Actor>().AbilityManager = am;
        p.GetComponent<Actor>().World = this;
    }

    void Update()
    {
        
    }
}
