namespace Assets.Scripts.BoardGeneration.Tiles
{
    public abstract class TileBase : ITile
    {
        public TileData TileData { get; private set; }

        public void SetTileData(TileData tileData)
        {
            TileData = tileData;
        }
    }
}