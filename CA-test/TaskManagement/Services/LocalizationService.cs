using System.Reflection;
using TaskManagement.Contants;

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
