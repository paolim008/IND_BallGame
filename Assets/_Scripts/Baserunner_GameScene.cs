using System;
using UnityEngine;

public class Baserunner_GameScene : MonoBehaviour
{
    private void Start()
    {
    }

    private void CreateScriptObject(Type component)
    {
        GameObject baseRunnerGameObject = new GameObject();
        baseRunnerGameObject.name = name;
        
        baseRunnerGameObject.AddComponent(component);
        
        baseRunnerGameObject.transform.position = Vector3.zero;
        baseRunnerGameObject.transform.rotation = Quaternion.identity;
    }
    
}

