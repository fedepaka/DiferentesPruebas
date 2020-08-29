namespace Opedo.Licensing
{
    public class ModifyUserRequest
    {
        /// <summary>
        /// Target email for the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The name of the user
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        /// Contact phone number of the user
        /// </summary>
        public string UserPhone { get; set; }
    }
}
