/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.ObjectModel;

namespace SAPS.Codigo_Fuente.Ayudantes
{
    /* @brief Clase que encapsula los método para realizar funciones hash a las contraseñas.
     * 
     * Estos metodos se obtuvieron de:
     * genera_salt y hash_contrasena: https://msdn.microsoft.com/en-us/library/aa545602(v=cs.70).aspx
     * valida_contrasena: https://msdn.microsoft.com/en-us/library/aa545760(v=cs.70).aspx
    */
    public class Seguridad
    {
        // Variables de instancia

        private const int m_valor_salt = 4;

        // Name of the user profile.
        const string UserProfileName = "UserObject";

        // Property that holds the logon name.
        const string UserLoginPropertyName = "GeneralInfo.email_address";

        // Property that holds the password.
        const string UserPasswordPropertyName = "GeneralInfo.user_security_password";

        private static string[] HashingAlgorithms = new string[] { "SHA256", "MD5" };


        // Constructor
        public Seguridad()
        {

        }


        // Métodos

        // Hashing algorithms used to verify one-way-hashed passwords:
        // MD5 is used for backward compatibility with Commerce Server 2002. If you have no legacy data, MD5 can be removed.
        // SHA256 is used on Windows Server 2003.
        // SHA1 should be used on Windows XP (SHA256 is not supported).
        public bool valida_contrasena_hash(string password, string profilePassword)
        {
            int saltLength = m_valor_salt * UnicodeEncoding.CharSize;

            if (string.IsNullOrEmpty(profilePassword) ||
                string.IsNullOrEmpty(password) ||
                profilePassword.Length < saltLength)
            {
                return false;
            }

            // Strip the salt value off the front of the stored password.
            string saltValue = profilePassword.Substring(0, saltLength);

            foreach (string hashingAlgorithmName in HashingAlgorithms)
            {
                HashAlgorithm hash = HashAlgorithm.Create(hashingAlgorithmName);
                string hashedPassword = funcion_hash(password, saltValue, hash);
                if (profilePassword.Equals(hashedPassword, StringComparison.Ordinal))
                    return true;
            }

            // None of the hashing algorithms could verify the password.
            return false;
        }

        public string hash_constrasena(string contrasena)
        {
            // TO-DO: Hashear la contraseña
            return "foobar";
        }


        // Métodos privados

        private static string genera_salt()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();

            if (utf16 != null)
            {
                // Create a random number object seeded from the value
                // of the last random seed value. This is done
                // interlocked because it is a static value and we want
                // it to roll forward safely.

                Random random = new Random(unchecked((int)DateTime.Now.Ticks));

                if (random != null)
                {
                    // Create an array of random values.

                    byte[] saltValue = new byte[m_valor_salt];

                    random.NextBytes(saltValue);

                    // Convert the salt value to a string. Note that the resulting string
                    // will still be an array of binary values and not a printable string. 
                    // Also it does not convert each byte to a double byte.

                    string saltValueString = utf16.GetString(saltValue);

                    // Return the salt value as a string.

                    return saltValueString;
                }
            }

            return null;
        }

        private static string funcion_hash(string clearData, string saltValue, HashAlgorithm hash)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();

            if (clearData != null && hash != null && encoding != null)
            {
                // If the salt string is null or the length is invalid then
                // create a new valid salt value.

                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = genera_salt();
                }

                // Convert the salt string and the password string to a single
                // array of bytes. Note that the password string is Unicode and
                // therefore may or may not have a zero in every other byte.

                byte[] binarySaltValue = new byte[m_valor_salt];

                binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                byte[] valueToHash = new byte[m_valor_salt + encoding.GetByteCount(clearData)];
                byte[] binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, m_valor_salt);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                string hashedPassword = saltValue;

                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.

                return hashedPassword;
            }

            return null;
        }

    }
}