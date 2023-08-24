using Common;
using Common.Model.Core;
using Common.Model.Settings.Providers;
using FluentValidation;
using PhoneNumbers;

namespace API.Model.Providers.Phone.DTOs.Request;

public class PhoneVerificationRequestDto
{
    public string PhoneNumber { get; set; }
    
    public string? Region { get; set; }
    public Platform? Platform { get; set; }
    
    public class Validator : AbstractValidator<PhoneVerificationRequestDto>
    {
        private readonly PhoneAuthProviderSetting _setting;
    
        public Validator(Settings setting)
        {
            _setting = setting.AuthProviderSettings.PhoneAuthProviderSetting;

            RuleFor(dto => dto.Platform)
                .Cascade(CascadeMode.Stop)
                .IsInEnum();

            RuleFor(dto => dto.Region)
                .Cascade(CascadeMode.Stop)
                .Must(BeAValidIsoRegion!)
                .When(dto => !string.IsNullOrWhiteSpace(dto.Region))
                .WithMessage("Region not supported.");
        
            RuleFor(dto => dto.PhoneNumber)
                .NotEmpty()
                .Must((dto, s) => BeAValidPhoneNumber(s, dto.Region))
                .WithMessage("Invalid phone number format.");
        }

        private bool BeAValidIsoRegion(string region)
        {
            return _setting.ExcludedCountries.IndexOf(region.ToUpper()) == -1 && _setting.AllowedCountries.IndexOf(region.ToUpper()) != -1;
        }

        private bool BeAValidPhoneNumber(string phoneNumber, string? region)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            try
            {
                var phoneNumberObject = phoneNumberUtil.ParseAndKeepRawInput(phoneNumber, region);
                return phoneNumberUtil.IsValidNumber(phoneNumberObject) && phoneNumberUtil.IsPossibleNumberForType(phoneNumberObject, PhoneNumberType.MOBILE);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}