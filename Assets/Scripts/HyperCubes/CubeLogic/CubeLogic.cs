﻿using HypercubesPrototyp.GameLogic;
namespace HypercubesPrototyp.HyperCubeLogic
{
    public interface ICubeCommand
    {
#nullable enable
        public abstract void DoCommand(Lemming? lemming, HyperCube hyperCube);
    }
}