﻿using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StockBoard.Application.AutoMapper;

namespace StockBoard.Service.Api.Configurations
{
  public static class AutoMapperSetup
  {
      public static void AddAutoMapperSetup(this IServiceCollection services)
      {
          if (services == null) throw new ArgumentNullException(nameof(services));

          services.AddAutoMapper();

          AutoMapperConfig.RegisterMappings();
      }
  }
}