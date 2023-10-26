﻿using System;
using UnityEngine;
using static IInputService;

public class BootstrapState : IState
{
    private const string InitialScene = "Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        RegisterServices();
        _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>("Test");
    }

    private void RegisterServices()
    {
        Game.InputService = RegisterInputService();
    }

    public void Exit()
    {

    }

    private static IInputService RegisterInputService()
    {
        if (Application.isEditor)
        {
            return new StandaloneInputService();
        }
        else
            return new MobileInputService();
    }
}
