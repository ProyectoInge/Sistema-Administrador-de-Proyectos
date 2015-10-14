/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Security.Cryptography;

namespace SAPS.Ayudantes
{
    /* @brief Clase que encapsula los método para realizar funciones hash a las contraseñas. */
    public class Seguridad
    {

        /** @brief Método que compara la igualdad de dos contraseñas
         *  @param contrasena_a_probar contraseña en texto plano que se planea probar su validez.
         *  @param contrasena_guardada contraseña *hasheada* con la que se hará la comparación.
         *  @return true si las contraseñas concuerdan. false en caso contrario.
        */
        public static bool valida_contrasena_hash(string contrasena_a_probar, string contrasena_guardada)
        {
            bool autorizado = true;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(contrasena_guardada);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(contrasena_a_probar, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    autorizado = false;
                }
            }
            return autorizado;
        }

        /** @brief Convierte una contraseña en texto plano mediante una función hash
          * a una serie de caracteres de longitud variable.
          * @param contrasena texto plano a ser convertido mediante la función hash.
          * @return string con el resultado de la función hash.
        */
        public static string hash_constrasena(string contrasena)
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
            System.Diagnostics.Debug.Write("HASHED PWD: " + hashed);
            return hashed;
        }

    }
}