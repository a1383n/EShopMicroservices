namespace API.Model.Providers.Phone.DTOs.Request;

public record PhoneNumber(string areaCode, string phone);

public record PhoneVerificationRequestDTO(PhoneNumber PhoneNumber);