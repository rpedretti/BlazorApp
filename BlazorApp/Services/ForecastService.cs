﻿using BlazorApp.Domain;
using Microsoft.AspNetCore.Blazor;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ForecastService : IForecastService
    {
        #region Fields

        private readonly HttpClient httpClient;

        #endregion Fields

        #region Constructors

        public ForecastService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #endregion Constructors

        #region Methods

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return await httpClient.GetJsonAsync<WeatherForecast[]>("/sample-data/weather.json"); ;
        }

        #endregion Methods
    }
}
