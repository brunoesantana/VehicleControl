namespace VehicleControl.Mapper
{
    public class MapperConfig
    {
        private static bool _isMapped;

        public static void RegisterMappings()
        {
            if (_isMapped)
                return;

            _isMapped = true;

            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.AddProfile<MapperDto2Entity>();
                mapper.AddProfile<MapperEntity2Dto>();
            });
        }
    }
}
