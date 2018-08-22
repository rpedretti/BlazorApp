﻿using System.Collections.Generic;

namespace RPedretti.Blazor.BingMaps.Entities
{
    public class BingMapsViewConfig
    {
        public BingMapsViewConfig() { }

        public BingMapsViewConfig(BingMapsViewConfig viewConfig)
        {
            Zoom = viewConfig.Zoom;
            MapTypeId = viewConfig.MapTypeId;
        }

        public int Zoom { get; set; } = 10;
        public string MapTypeId { get; set; }
        public Geocoordinate Center { get; set; }

        public override bool Equals(object obj)
        {
            var config = obj as BingMapsViewConfig;
            return config != null &&
                   Zoom == config.Zoom &&
                   MapTypeId == config.MapTypeId &&
                   EqualityComparer<Geocoordinate>.Default.Equals(Center, config.Center);
        }

        public override int GetHashCode()
        {
            var hashCode = -1051533646;
            hashCode = hashCode * -1521134295 + Zoom.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MapTypeId);
            hashCode = hashCode * -1521134295 + EqualityComparer<Geocoordinate>.Default.GetHashCode(Center);
            return hashCode;
        }
    }
}
