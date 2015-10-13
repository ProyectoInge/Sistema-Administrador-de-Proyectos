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

namespace SAPS.Ayudantes
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
                //string hashedPassword = funcion_hash(password, saltValue, hash);
               // if (profilePassword.Equals(hashedPassword, StringComparison.Ordinal))
                    return true;
            }

            // None of the hashing algorithms could verify the password.
            return false;
        }

        public string hash_constrasena(string contrasena)
        {
            /// @todo Hashear la contraseña
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(contrasena, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashed = Convert.ToBase64String(hashBytes);

            //DEBUG
            System.Diagnostics.Debug.Write("HASHED PWD: "+hashed);
            return hashed;
        }
    }
}