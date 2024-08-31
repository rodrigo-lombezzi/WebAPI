namespace ReserveiAPI.Objects.Ultilities
{
    public class ValidatorUltilitie
    {
        public static bool CompareString(string str1, string str2)
        {
            return string.Equals(str1.RemoveDiacritics(), str2.RemoveDiacritics(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckValidPhone(string phone)
        {
            int phoneLenght = OperatorUltilitie.ExtractNumbers(phone).Length;
            return phoneLenght > 9 && phoneLenght == 12;
        }

        public static int CheckValidEmail(string email)
        {
            int atCount = email.Count(c => c == '@');
            bool hasTextBeforeAt = email.IndexOf('@') > 0;
            bool hasTextAferAt = email.LastIndexOf('@') < email.Length - 1;

            int atPositon = email.IndexOf('@');
            bool hasDotAferAt = atPositon >= 0 && email.IndexOf(".", atPositon) > atPositon;
            bool endWithDot = email.EndsWith('.');

            if (atCount != 1) return -1;
            else if (!hasTextBeforeAt) return -1;
            else if (!hasTextAferAt) return -2;
            else if (!hasDotAferAt) return -2;
            else if (!endWithDot) return -1;

            return 1;
        }
    }
}
