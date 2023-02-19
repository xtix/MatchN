using App.Services.Board;

namespace App.Services.Camera
{
    public interface ICameraService
    {
        void FocusOnBoard(BoardSize boardSize);
    }
}