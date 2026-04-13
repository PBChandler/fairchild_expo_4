using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ImageInvestigation : MonoBehaviour
{
    public List<PointNClickTag> pointNClickObjects = new List<PointNClickTag>();
    public List<PointNClickTag> foundTags = new List<PointNClickTag>();

    public delegate void onItemFound(PointNClickTag tag);
    public onItemFound dg_onItemFound;

    public GameState gameState;
    public delegate void onGameStateChanged(GameState state);
    public onGameStateChanged dg_onGameStateChanged;

    public GameObject PauseMenuParent;

    [Header("SFX Stuff")]
    public AudioSource divinity;
    public AudioClip onPaused;


    [System.Serializable]
    public enum GameState
    {
        NULL,
        Title,
        Paused,
        Quit,
        Playing,
    }

    public void Start()
    {
        dg_onGameStateChanged += HandleLayers;
    }

    public void Pause()
    {
        divinity.clip = onPaused;
        divinity.Play();
        SetState(GameState.Paused);
    }

    public void Resume()
    {
        SetState(GameState.Playing);
    }
    public void SetState(GameState state)
    {
        gameState = state;
        dg_onGameStateChanged(state);
    }
    /// <summary>
    /// Handle the layers of the GameState changes.
    /// </summary>
    public void HandleLayers(GameState state)
    {
        switch (state)
        {
            case GameState.NULL:
                break;
            case GameState.Title:
                PauseMenuParent.SetActive(false);
                break;
            case GameState.Paused:
                PauseMenuParent.SetActive(true);
                break;
            case GameState.Quit:
                PauseMenuParent.SetActive(false);
                break;
            case GameState.Playing:
                PauseMenuParent.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void AddItem(PointNClickTag newItem)
    {
        switch (gameState)
        {
            case GameState.NULL:
                break;
            case GameState.Title:
                return;
            case GameState.Paused:
                return;
            case GameState.Quit:
                return;
            case GameState.Playing:
                break;
            default:
                break;
        }
        if(foundTags.Contains(newItem)) return;
        
        foundTags.Add(newItem);
        dg_onItemFound?.Invoke(newItem);
    }
    
    
    public void Update()
    {
        //debug
        if(Input.GetKeyDown(KeyCode.F))
        {
            AddItem(pointNClickObjects[Random.Range(0, pointNClickObjects.Count)]);
        }
    }
}
