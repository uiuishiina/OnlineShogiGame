
namespace KTC.Game
{
    public class FixToScale
    {
        private const uint _squaresCount = 9;

        private uint _boradSize = 0;
        private uint _frameSize = 0;

        public FixToScale(uint boardSize, uint frameSize)
        {
            _boradSize = boardSize;
            _frameSize = frameSize;
        }

        public float GetPieceSize(uint squaresCount = _squaresCount)
        {
            //  サイズ取得(そのままだとマスの大きさと一緒になるため 0.9倍 で仮調整)
            return (_boradSize - _frameSize * 2) / squaresCount * 0.9f;
        }

    }
}