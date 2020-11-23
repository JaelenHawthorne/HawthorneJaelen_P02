using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnPlayEffect", menuName = "CardData/PlayEffects/Heal")]

public class HealEffect : CardEffect
{
    [SerializeField] int _healAmount = 2;
    [SerializeField] GameObject _prefabToSpawn = null;

    

    public override void Activate(ITargetable target)
    {
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if (objectToDamage != null)
        {
            objectToDamage.healPlayer(_healAmount);
        }


        MonoBehaviour worldObject = target as MonoBehaviour;

        if (worldObject != null)
        {
            Vector3 spawnLocation = worldObject.transform.position;
            GameObject newGameObject = Instantiate(_prefabToSpawn, spawnLocation, Quaternion.identity);
            Debug.Log("Spawn new Object: " + newGameObject.name);

            Destroy(newGameObject, 1);
        }
        else
        {
            Debug.Log("Target does not have a transform...");
        }
    }
}
