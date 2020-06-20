using System.Collections.Generic;
using Actors;
using Modifiers;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Dictionary<Modifier, List<Actor>> Modifiers { get; set; }
    public World World { get; set; }

    void Start()
    {
    }

    void Update()
    {
        foreach (var entry in Modifiers)
        {
            foreach (var actor in entry.Value)
            {
                entry.Key.Execute(actor);
            }
        }
    }

    public void AddEntry(Modifier modifier, List<Actor> targets)
    {
        modifier.world = World;
        Modifiers.Add(modifier, targets);
    }
}