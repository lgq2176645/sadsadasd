﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Tensee.Banch.Editions.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}