using System;
using System.Collections.ObjectModel;
using BDD_Test_Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD_Test_Framework.Helpers
{
    public static class ElementConverter
    {
        public static IWebElement ConvertToElement(this string value, BasePage page)
        {
            var element = ConvertToObject(value, page);
            try
            {
                return (IWebElement)element;
            }
            catch (InvalidCastException)
            {
                return ((SelectElement)element).WrappedElement;
            }
        }

        public static ReadOnlyCollection<IWebElement> ConvertToElements(this string value, BasePage page)
        {
            return (ReadOnlyCollection<IWebElement>)ConvertToObject(value, page);
        }

        private static object ConvertToObject(this string value, BasePage page)
        {
            value = value.Trim();
            var properties = page.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var elementNameAttribute = (ElementNameAttribute[])properties[i].GetCustomAttributes(typeof(ElementNameAttribute), false);
                if (elementNameAttribute.Length == 0)
                {
                    continue;
                }

                if (string.Equals(elementNameAttribute[0].Description, value, StringComparison.CurrentCultureIgnoreCase))
                {
                    return properties[i].GetValue(page);
                }
            }

            return null;
        }
    }
}
