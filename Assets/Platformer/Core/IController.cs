using System;

namespace Platformer.Core
{
    public interface IController
    {
        event Action<GameState> OnControllerFinish;
        void Run();
    }
}