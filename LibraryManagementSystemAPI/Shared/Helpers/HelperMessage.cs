using System.Text;

namespace LibraryManagementSystemAPI.Shared.Helpers
{
    public static class HelperMessage
    {
        private static readonly Random random = new();



        public static readonly string OK = "Obtention avec succès des éléments";
        public static readonly string Login = "Connexion de l'Utilisateur avec succès";
        public static readonly string Updated = "Modification faites avec succès";
        public static readonly string Created = "Création faites avec succés";
        public static readonly string Deleted = "Suppression faites avec succés";
        public static readonly string FichierNotExist = "Aucun fichier ou image chargés";
        public static readonly string NoContent = "Aucun element trouvé dans la base de données";
        public static readonly string InternalServerError = "Erreur serveur contacter un admin";
        public static readonly string DataExist = "Erreur BD";
        public static readonly string ErrorDataBase = "Erreur d'envoie des données dans la BD";
        public static readonly string FileExtension = "Le fichier téléchargé doit être doc, docx, pdf, xls, xlsx";
        public static readonly string FileExtensionImg = "Le fichier téléchargé doit être png, jpeg, jpeg";
        public static readonly string FileMaxSize = "Le fichier est trop grand";

        public static readonly string BlockUser = "Uilisateur Bloqué";
        public static readonly string UnblockUser = "Uilisateur Debloqué";
        public static readonly string ActivateUser = "L'utilisateur Activé";
        public static readonly string DeactivateUser = "L'utilisateur Désactivé";

        public static string NotFoundElem(string element) => $"élément {element} non trouvé dans le systéme";
        public static string NotFoundLogin(string element) => $"Echec {element} de connexion dans le systéme";
        public static string BadRequestElem(string element) => $"Erreur de modification de cet {element} ";
        public static string BadRequestTokenInvalide(string element) => $"Token invalide {element} ";
        public static string BadRequestElemPassword(string element) => $"La longueur minimale du mot de passe doit être de 8 caractères, Le mot de passe doit être alphanumérique, Le mot de passe doit contenir un caractère spécial";
        public static string BadRequestSupp(string element) => $"Erreur de suppression de cet {element} ";
        public static string BadRequestDataExist(string element) => $" {element} existe déjà";
        public static string BadRequestDataEquilibre(string element) => $" {element} Le montant net à payer dôit être est égal au montant à payer : probléme d'équilibré";




        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public static string RandomCodeInvoice(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars + DateTime.UtcNow.ToString("dd/MM/yyyy").Replace("/", "-"), length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomCodeProduct(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars + DateTime.UtcNow.ToString("dd/MM/yyyy").Replace("/", "_"), length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomPaymentNo(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars + DateTime.UtcNow.ToString("dd/MM/yyyy").Replace("/", "_"), length).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetRandomFileName() + "_" + DateTime.UtcNow.ToString("dd/MM/yyyy").Replace("/", "_");
            return Path.GetFileNameWithoutExtension(fileName)
            + "_"
            + Guid.NewGuid().ToString().Substring(0, 4)
            + Path.GetExtension(fileName);
        }



        public static bool CheckFileContentType(string fileContentType)
        {
            string[] availableContentTypes = {
                 "application/pdf","application/vnd.ms-excel",
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                 "application/msword",
                 "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                 };
            if (availableContentTypes.Contains(fileContentType))
                return true;



            return false;
        }



        public static bool CheckFileContentTypeImg(string fileContentType)
        {
            string[] availableContentTypes = { "image/gif", "image/jpeg", "image/png" };
            if (availableContentTypes.Contains(fileContentType))
                return true;



            return false;
        }

        public static string GetFileUrl(string companyName)
        {
            string rootDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(rootDirectory, $"Uploaded\\{companyName}\\");

            return filePath.Replace("\\", "/");
        }


        public static Tuple<string, string> GetLastTwoElements(string input)
        {
            string[] elements = input.Split('/');

            if (elements.Length < 2)
            {
                throw new ArgumentException("La chaîne ne contient pas suffisamment d'éléments séparés par '/'");
            }

            string secondLast = elements[elements.Length - 2];
            string last = elements[elements.Length - 1];

            return Tuple.Create(secondLast, last);
        }

        public static byte[] GetImage(string sBaseString)
        {
            byte[]? bytes = null;

            if (!string.IsNullOrEmpty(sBaseString))
            {
                bytes = Convert.FromBase64String(sBaseString);
            }
            return bytes;
        }

        public static string EncodeBase64(this string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }

        public static string DecodeBase64(this string value)
        {
            var valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }




        public static byte[] GetFile(string sBaseString)
        {
            byte[]? bytes = null;



            if (!string.IsNullOrEmpty(sBaseString))
            {
                bytes = Convert.FromBase64String(sBaseString);
            }
            return bytes;
        }



    }
}
