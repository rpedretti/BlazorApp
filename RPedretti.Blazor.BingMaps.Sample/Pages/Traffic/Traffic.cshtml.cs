﻿using Microsoft.AspNetCore.Blazor.Components;
using RPedretti.Blazor.BingMaps.Entities;
using RPedretti.Blazor.BingMaps.Modules;
using RPedretti.Blazor.BingMaps.Modules.Directions;
using RPedretti.Blazor.BingMaps.Modules.Traffic;
using RPedretti.Blazor.BingMaps.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.Blazor.BingMaps.Sample.Pages
{
    public class TrafficBase: BaseComponent
    {
        [Inject] protected BingMapPushpinService BingMapPushpinService { get; set; }

        protected string BingMapId = $"bing-maps-{Guid.NewGuid().ToString().Replace("-", "")}";

        protected ObservableCollection<IBingMapModule> Modules = new ObservableCollection<IBingMapModule>();

        private bool _showIncidents = true;
        protected bool ShowIncidents
        {
            get => _showIncidents;
            set
            {
                if (SetParameter(ref _showIncidents, value))
                {
                    UpdateTraffic(true);
                }

            }
        }
        protected bool ShowTraffic { get; set; }

        private BingMapsTrafficModule _trafficModule;

        protected BingMapsConfig MapsConfig { get; set; } = new BingMapsConfig
        {
            MapTypeId = BingMapsTypes.GrayScale,
            SupportedMapTypes = new string[] {
                BingMapsTypes.Aerial,
                BingMapsTypes.GrayScale,
                BingMapsTypes.Road,
                BingMapsTypes.BirdsEyes
            },
            EnableHighDpi = true,
            Zoom = 12,
            ShowTrafficButton = true

        };

        protected async void UpdateTraffic(bool show)
        {
            ShowTraffic = show;
            if (!Modules.Any(m => m is BingMapsTrafficModule))
            {
                _trafficModule = new BingMapsTrafficModule();
                Modules.Add(_trafficModule);
                Console.WriteLine("Adding traffic module");
            }
            else
            {
                await _trafficModule.UpateTrafficAsync(new BingMapsTrafficOptions
                {
                    FlowVisible = ShowTraffic,
                    IncidentsVisible = ShowTraffic && ShowIncidents,
                    LegendVisible = ShowTraffic
                });
            }

            StateHasChanged();
        }

        public Task MapLoaded()
        {
            return Task.CompletedTask;
        }

        protected BingMapsViewConfig MapsViewConfig { get; set; } = new BingMapsViewConfig();
    }
}
