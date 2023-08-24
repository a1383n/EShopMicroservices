using Common.Model.Settings.Providers;
using Framework.Mapper;

namespace API.Model.Providers.Phone.DTOs.Response;

public record PhoneProviderSettingResponseDto(bool IsEnabled, bool IsTemporaryDown) : IMapFrom<PhoneAuthProviderSetting>;