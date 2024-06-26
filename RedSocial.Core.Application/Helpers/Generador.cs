
using System.Text;


namespace RedSocial.Core.Application.Helpers
{
    public static class Generador
    {
        private static readonly Random random = new Random();

        public static string GenerarContrasena(int longitud = 12)
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            StringBuilder contrasena = new StringBuilder();

            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteres.Length);
                contrasena.Append(caracteres[indice]);
            }

            return contrasena.ToString();
        }
    }
}
