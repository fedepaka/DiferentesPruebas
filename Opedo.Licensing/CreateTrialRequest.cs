namespace Opedo.Licensing
{
    public class CreateTrialRequest
    {
        /// <summary>
        /// Target email for the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name for the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name for the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Contact phone number of the user
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// Identifier for the product to create trial for
        /// </summary>
        public string Product { get; set; }
    }
}
