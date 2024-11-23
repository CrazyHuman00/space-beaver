namespace InGame.System
{
    public interface IStar
    {
        /// <summary>
        /// 星の位置を確認する。
        /// </summary>
        void CheckStarPosition();
        
        /// <summary>
        /// 星を破壊する。
        /// </summary>
        void DestroyStar();

        /// <summary>
        /// 星を動かす。
        /// </summary>
        void MoveStar();
        
        /// <summary>
        /// 星をスタートの位置にセットする。
        /// </summary>
        void SetStartPosition();
    }
}