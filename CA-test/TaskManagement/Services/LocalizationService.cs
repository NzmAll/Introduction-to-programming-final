using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contants;
using TaskManagement.Exceptions;
using TaskManagement.Utilities;

namespace TaskManagement.Services
{
    public class LocalizationService
    {
        public static SupportedCulture CurrentCulture { get; set; } = SupportedCulture.Russian;

        public static string GetTranslation(TranslationKey key)
        {
            Type translationConstantType = typeof(TranslationConstant);

            string fieldName = $"{key}_{CurrentCulture}";
            FieldInfo fieldInfo = translationConstantType.GetField(fieldName)!;

            return (string)fieldInfo.GetValue(null);
        }

    }
}
