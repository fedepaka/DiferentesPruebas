namespace Opedo.Licensing
{
    /// <summary>
    /// Response state from a licensing server
    /// </summary>
    public enum LicenseResponseState
    {
        None,
     
        /// <summary>
        /// The user was successfully assigned a license
        /// </summary>
        Success,

        /// <summary>
        /// The user has had a trial license created for them
        /// </summary>
        Success_TrialCreated,

        /// <summary>
        /// Generic failure
        /// </summary>
        Failure,

        /// <summary>
        /// The user was authenticated, but the company to which the user belongs
        /// do not have any available module licenses and have specified that exceeding
        /// their allocation is not allowed. The user should be asked to contact their licensing department.
        /// </summary>
        Failure_NoModulesAvailable,

        /// <summary>
        /// The user was authenticated, but the assigned license has expired.
        /// The user should be asked to contact their licensing department.
        /// </summary>
        Failure_LicenseExpired,

        /// <summary>
        /// There is no license for the specified product
        /// </summary>
        Failure_NoLicense,

        /// <summary>
        /// Cannot create a trial since the user already has created one previously
        /// </summary>
        Failure_TrialAlreadyCreated
    }
}
