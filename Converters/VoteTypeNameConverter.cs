using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ms.Converters
{
    public class VoteTypeNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string voteType)
            {
                switch (voteType)
                {
                    case "POSITIVE_VOTE":
                        return "Yes";
                    case "NEUTRAL_VOTE":
                        return "Maybe";
                    case "NEGATIVE_VOTE":
                        return "No";
                    default:
                        return voteType;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
