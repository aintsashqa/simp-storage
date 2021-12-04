using System;

namespace SimpStorage.WebClient.Models
{
    public record FileLookupItem(
        Guid Id,
        string Filename,
        long Size,
        DateTime UploadedAtDate
    )
    {
        private enum SizeUnit
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        public string SizeToString()
        {
            var (value, unit) = Convert(0);
            return $"{value.ToString("0.00")} {((SizeUnit)unit).ToString()}";
        }

        private (double, int) Convert(int unit)
        {
            var value = (Size / (double)Math.Pow(1024, (Int64)unit));
            if (value >= 1000)
            {
                return Convert(unit + 1);
            }

            return (value, unit);
        }
    }
}
