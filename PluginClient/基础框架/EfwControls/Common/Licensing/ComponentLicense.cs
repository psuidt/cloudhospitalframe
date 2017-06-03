using System;
using System.Linq;
using System.ComponentModel;

namespace EfwControls.Common.Licensing
{
    /// <summary>
    /// License granted to components.
    /// </summary>
    public class ComponentLicense : License
    {

        #region Documentation

        /*
         * This is a very simple example. You could expand this example by storing more information
         * in the license key. For example, you could store a byte array of license information such
         * as instances, features, etc., then change that to a base-64 number that can be saved and
         * retrieved. Using a CRC or some other embedded check helps to keep fakes at bay. You can
         * get as creative as you want in the VerifyKey function, such as only allow the user to use
         * the control on certain dates, or it could even check a web service for subscription based
         * licenses. 
         * 
         * It is important to note though to keep as much of your code as possible private or internal
         * so that your obfuscation programs can really mangle the names. This will keep hackers from
         * easily reverse-engineering or disabling your license system.
        */

        #endregion

        #region Fields

        private string _licKey = string.Empty;
        private string _controlName = string.Empty;
        private bool _isDemo = false;
        private bool _disposed = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the license key granted to this component.
        /// </summary>
        public override string LicenseKey
        {
            get { return _licKey; }
        }

        /// <summary>
        /// Gets if this component is running in demo mode.
        /// </summary>
        public bool IsDemo
        {
            get { return _isDemo; }
        }

        #endregion

        #region Construction / Deconstruction

        /// <summary>
        /// Creates a new <see cref="ComponentLicense"/> object.
        /// </summary>
        /// <param name="licKey">License key to use.</param>
        private ComponentLicense(string licKey,string controlname)
        {
            _licKey = licKey;
            _controlName = controlname;
            if (!VerifyKey())
                _isDemo = true;
        }

        /// <summary>
        /// Disposes this object.
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposes this object.
        /// </summary>
        /// <param name="disposing">true if the object is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    //Custom disposing here.
                }
                _disposed = true;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a demo <see cref="ComponentLicense"/>.
        /// </summary>
        /// <returns>A demo <see cref="ComponentLicense"/>.</returns>
        internal static ComponentLicense CreateDemoLicense()
        {
            return new ComponentLicense(string.Empty,string.Empty);
        }

        /// <summary>
        /// Attempts to create a new <see cref="ComponentLicense"/> with the specified key.
        /// </summary>
        /// <param name="developerKey">Developer Key</param>
        /// <returns><see cref="ComponentLicense"/> with the specified fields set.</returns>
        internal static ComponentLicense CreateLicense(string developerKey,string controlname)
        {
            return new ComponentLicense(developerKey,controlname);
        }

        #endregion

        #region Private Methods

        private bool VerifyKey()
        {

            if (string.IsNullOrEmpty(_licKey))
                return false;

            //Now let's compare the CRC to make sure its a valid key
            //if (string.Equals(splitKey[5], baseCRC.ToString("X8"), StringComparison.OrdinalIgnoreCase))
            //    return true;
            string name = _controlName;
            name = name.Length < 8 ? name.PadRight(8, '*') : name;
            EfwControls.Common.DESEncryptor des = new EfwControls.Common.DESEncryptor(name, name);
            des.InputString = _licKey;
            des.DesDecrypt();
            DateTime date = Convert.ToDateTime(des.OutString);
            if (date > DateTime.Now)
                return true;
            return false;
        }

        #endregion

    }
}
