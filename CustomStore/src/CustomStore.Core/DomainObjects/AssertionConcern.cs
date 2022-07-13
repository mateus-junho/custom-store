
using System.Text.RegularExpressions;

namespace CustomStore.Core.DomainObjects
{
    public class AssertionConcern
    {
        public static void ValidateEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateDifferent(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateSize(string value, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidadeLenght(string value, int min, int max, string message)
        {
            var length = value.Trim().Length;
            if (length < min || length > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinMax(double value, double min, double max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinMax(float value, float min, float max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinMax(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinMax(long value, long min, long max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinMax(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(long value, long min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateGreaterThan(double value, double min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(decimal value, decimal min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(int value, int min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessOrEqualsThan(decimal value, decimal min, string message)
        {
            if (value <= min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateFalse(bool boolvalue, string message)
        {
            if (!boolvalue)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateTrue(bool boolvalue, string message)
        {
            if (boolvalue)
            {
                throw new DomainException(message);
            }
        }
    }
}
