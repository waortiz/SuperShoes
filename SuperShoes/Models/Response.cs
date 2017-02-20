namespace SuperShoes.Api.Models
{
    /// <summary>
    /// Information of the response class.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets if the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary
        public string ErrorMessage { get; set; }
        
    }
}