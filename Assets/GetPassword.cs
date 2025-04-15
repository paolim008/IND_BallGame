using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering.VirtualTexturing;

public class GetPassword : MonoBehaviour
{
    public static GetPassword Instance;
    [SerializeField] private GameObject meetTheDevelopersPanel;
    private string currentString = "";

    private enum Passwords
    {
        MEETTHEDEVELOPERS,
        MEETTHEARTISTS
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this);
    }

    void Start()
    {
        meetTheDevelopersPanel.SetActive(false);   
    }

    void Update()
    {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                string keyString = key.ToString();
                
                if (keyString.StartsWith("Mouse")) return;
                if (keyString.StartsWith("Alpha")) keyString = keyString.Replace("Alpha", ""); // Remove the "Alpha" prefix
                
                currentString += keyString;


                foreach (Passwords passwordEnum in Enum.GetValues(typeof(Passwords)))
                {
                    if (currentString.Contains(passwordEnum.ToString()))
                    {
                        OnPasswordEntered(passwordEnum);
                        currentString = "";
                        return;
                    }
                }
            }
        }

    }

    private void OnPasswordEntered(Passwords password)
    {
        switch (password)
        {
            case Passwords.MEETTHEDEVELOPERS:
                StartCoroutine(ShowDeveloperPanel());
                break;
            case Passwords.MEETTHEARTISTS:
                break;

        }
    }

    private IEnumerator ShowDeveloperPanel()
    {
        meetTheDevelopersPanel.SetActive(true);
        yield return new WaitForSeconds(10f);
        meetTheDevelopersPanel.SetActive(false);
    }
}
