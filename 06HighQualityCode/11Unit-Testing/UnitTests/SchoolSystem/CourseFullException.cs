namespace SchoolSystem
{
    using System;
    using System.Runtime.Serialization;

    public class CourseFullException : Exception, ISerializable
    {
        public CourseFullException()
            : base()
        {
        }

        public CourseFullException(string message)
            : base(message)
        {
        }

        public CourseFullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CourseFullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}