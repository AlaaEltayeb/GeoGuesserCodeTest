namespace Assets.Scripts.BoardGeneration.Tiles
{
    public interface ITile
    {
        TileData TileData { get; }

        void SetTileData(TileData tileData);
    }
}