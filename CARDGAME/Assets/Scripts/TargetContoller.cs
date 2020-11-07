using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetContoller : MonoBehaviour
{
    //TODO build more structured connection
    public static ITargetable CurrentTarget;
    // interface dont stabalize, so no need class refrence
    [SerializeField] Creature _objectToTarget = null;

    private void Update()
    {
        // target the object when '1' is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // target the object, if it is targetable
            ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
            if(possibleTarget != null)
            {
                Debug.Log("New target Acquired!");
                CurrentTarget = possibleTarget;
                _objectToTarget.Target();
            }

        }
    }

    public void TargetCreature()
    {
        // target the object, if it is targetable
        ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
        if (possibleTarget != null)
        {
            Debug.Log("New target Acquired!");
            CurrentTarget = possibleTarget;
            _objectToTarget.Target();
        }
    }
}
