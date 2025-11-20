using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Settings;

public sealed class GetSettingByIdSpec : Specification<Setting>
{
    public GetSettingByIdSpec(int settingId)
    {
        Query
            .Where(setting => setting.Id == settingId);
    }
}