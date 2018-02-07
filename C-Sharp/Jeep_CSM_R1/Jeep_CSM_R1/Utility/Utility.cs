using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;



namespace Utility
{

    public static class ObjectCopier
    {
        /// <summary>
        /// Does a shallow copy of two objects of the same type.   The copy is limited to property
        /// values only.  This is a handy copy method since it will call Propertychanged (if defined)
        /// when the property values are changed.  The bad news is that it's a shallow copy so properties 
        /// that are a reference won't necessaily work as desired (ie a Binding List).  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static Boolean CopyShallow<T>(T source, T dest)
        {
            //foreach (PropertyInfo oPropertyInfo in oCostDept.GetType().GetProperties())
            foreach (PropertyInfo oPropertyInfo in source.GetType().GetProperties())
            {
                //Check the method is not static
                if (!oPropertyInfo.GetGetMethod().IsStatic)
                {
                    //Check this property can write
                    if (source.GetType().GetProperty(oPropertyInfo.Name).CanWrite)
                    {
                        //Check the supplied property can read
                        if (oPropertyInfo.CanRead)
                        {
                            //Update the properties on this object
                            dest.GetType().GetProperty(oPropertyInfo.Name).SetValue(dest, oPropertyInfo.GetValue(source, null), null);
                        }
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            try
            {
                using (stream)
                {
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }
            catch (Exception exp)
            {
                String s = exp.Message;
                // Utility.TraceMessage("Error In Object Clone.  Message: " + s);
                //ErrorReporter.ReportError("Exception caught In ObjectCopier:Clone " + exp.Message, ErrorReporter.ErrorReporterStreams.ID_MESSAGE);
                return default(T);
            }
        }
    }
}
