namespace SuperShoes.Repositories.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for record not foud exception.
    /// </summary>
    [Serializable]
    public class RecordNotFoudException : Exception
    {
        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public RecordNotFoudException()
        {
        }

        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public RecordNotFoudException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with message and exception.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RecordNotFoudException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor with info and context.
        /// </summary>
        /// <param name="info">Info of the exception.</param>
        /// <param name="context">Context of the exception.</param>
        protected RecordNotFoudException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}