using System;
using System.ComponentModel;
using System.Reflection;

namespace EfwControls.Common.Licensing
{

    /// <summary>
    /// Provides Component License Validation
    /// </summary>
    public class ComponentLicenseProvider : LicenseProvider
    {

        #region Public Methods

        /// <summary>
        /// Gets a license for an instance or type of component.
        /// </summary>
        /// <param name="context">A <see cref="LicenseContext"/> that specifies where you can use the licensed object.</param>
        /// <param name="type">A <see cref="System.Type"/> that represents the component requesting the license.</param>
        /// <param name="instance">An object that is requesting the license.</param>
        /// <param name="allowExceptions">true if a <see cref="LicenseException"/> should be thrown when the component cannot be granted a license; otherwise, false.</param>
        /// <returns>A valid <see cref="License"/>.</returns>
        public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            //Here you can check the context to see if it is running in Design or Runtime. You can also do more
            //fun things like limit the number of instances by tracking the keys (only allow X number of controls
            //on a form for example). You can add additional data to the instance if you want, etc. 

            try
            {
                string devKey = GetDeveloperKey(type);

                return ComponentLicense.CreateLicense(devKey,type.Name);      //Returns a demo license if no key.
            }
            catch (LicenseException le)
            {
                if (allowExceptions)
                    throw le;
                else
                    return ComponentLicense.CreateDemoLicense();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns the string value of the DeveloperKey static property on the control.
        /// </summary>
        /// <param name="type">Type of licensed component with a DeveloperKey property.</param>
        /// <returns>String value of the developer key.</returns>
        /// <exception cref=""
        private string GetDeveloperKey(Type type)
        {
            PropertyInfo pInfo = type.GetProperty("DeveloperKey");

            if (pInfo == null)
                throw new LicenseException(type, null, "The licensed control does not contain a DeveloperKey static field. Contact the developer for assistance.");

            string value = pInfo.GetValue(null, null) as string;

            return value;
        }

        #endregion
        
    }
}
