using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Tensee.Banch.Editions.Dto;
using Tensee.Banch.Web.Areas.AppAreaName.Models.Common;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionEditOutput))]
    public class CreateOrEditEditionModalViewModel : GetEditionEditOutput, IFeatureEditViewModel
    {
        public bool IsEditMode => Edition.Id.HasValue;

        public IReadOnlyList<ComboboxItemDto> EditionItems { get; set; }

        public IReadOnlyList<ComboboxItemDto> FreeEditionItems { get; set; }

        public CreateOrEditEditionModalViewModel(GetEditionEditOutput output, IReadOnlyList<ComboboxItemDto> editionItems, IReadOnlyList<ComboboxItemDto> freeEditionItems)
        {
            EditionItems = editionItems;
            FreeEditionItems = freeEditionItems;
            output.MapTo(this);
        }
    }
}