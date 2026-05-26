using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.EventSystems;
public enum GameState
{
    Title,//タイトル画面
    Start,//ゲームイベント開始
    Prepare,//ポーズ画面
    Playing,//ゲーム中
    End//ゲームクリアorゲームオーバー
}

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    public static GameManager Instance { get; private set; }

    public StageManager stageManager;
    public EventManager eventManager;
    public GameState State { get; private set; } 

    public int CurrentFloor;
    private GameState currentGameState;// 現在の状態

    void Awake()
    {
        //インスタンス作成
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SetCurrentState(GameState.Start);
    }

    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        State= state;
        OnGameStateChanged(currentGameState);
    }

    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                break;
            case GameState.Start:
                StartEvent();
                break;
            case GameState.Prepare:
                Prepare();
                break;
            case GameState.Playing:
                Playing();
                break;
            case GameState.End:
                EndEvent();
                break;
            default:
                break;
        }
    }


    private void StartEvent()//最初のイベント
    {
        stageManager.EventSet();
        eventManager.StartEvent();
    }


    private void Prepare()//ポーズ画面になったら
    {
        SetCurrentState(GameState.Playing);
    }

    private void Playing()//プレイ中
    {
        stageManager.GameStart();
    }


    private void EndEvent()//ゲームクリアイベント
    {

    }
}
