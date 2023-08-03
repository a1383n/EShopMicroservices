namespace Common.Model.Settings.Global
{
    /// <summary>
    /// Specifies the type of verification code.
    /// </summary>
    public enum VerificationCodeType
    {
        Numeric,
        UpperCaseCharacter,
        LowerCaseCharacter,
        MixedCaseCharacter,
        AlphaNumeric,
    }

    /// <summary>
    /// Settings for generating verification codes.
    /// </summary>
    public class VerificationCodeSettings
    {
        /// <summary>
        /// Gets or sets whether the verification code length is dynamic.
        /// </summary>
        public bool IsDynamicLength { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the dynamic verification code length should be odd.
        /// </summary>
        public bool ShouldDynamicIsOdd { get; set; } = true;

        /// <summary>
        /// Gets or sets the minimum code length for dynamic verification codes.
        /// </summary>
        public byte? MinimumDynamicCodeLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum code length for dynamic verification codes.
        /// </summary>
        public byte? MaximumDynamicCodeLength { get; set; }

        /// <summary>
        /// Gets or sets the default length of the verification code.
        /// </summary>
        public byte CodeLength { get; set; } = 4;

        /// <summary>
        /// Gets or sets the type of verification code to be used.
        /// </summary>
        public VerificationCodeType CodeType { get; set; } = VerificationCodeType.Numeric;
    }
}