using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Personalization
{
    public interface IPreferenceService
    {
        Result<PreferenceDto> Create(PreferenceDto preference);
    }
}
