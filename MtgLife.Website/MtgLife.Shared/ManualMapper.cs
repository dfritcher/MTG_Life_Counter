using System;

namespace MtgLife.Shared
{
    public static class ManualMapper
    {
        public static T Assign<T>(this object source) where T : new()
        {
            var destination = new T();
            object destobj = destination;
            var destProperties = destobj.GetType().GetProperties();
            var sourceProperties = source.GetType().GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name &&
                        destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType) && destProperty.CanWrite)
                    {
                        var obj = sourceProperty.GetValue(source);


                        try
                        {
                            destProperty.SetValue(destobj, obj);

                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    }
                }
            }

            return (T)destobj;
        }
    }
}
