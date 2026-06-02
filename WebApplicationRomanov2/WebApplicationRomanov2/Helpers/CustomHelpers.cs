using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WebApplicationRomanov2.Models;


namespace WebApplicationRomanov2.Helpers
{
    public static class CustomHelpers
    {
        // Внешний параметризованный метод
        public static MvcHtmlString BoatListExternal(this HtmlHelper html, List<Boat> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table' border='1' cellpadding='5'><tr><th>Лодочная станция (Внешний хелпер)</th><th>Действия</th></tr>");

            int i = 0;
            // Использование цикла while (Вариант В)
            while (i < items.Count)
            {
                var item = items[i];
                sb.Append($"<tr><td>{item.BoatName}</td><td><a href='/Boat/Details/{item.Id}'>Просмотр</a> | <a href='/Boat/Edit/{item.Id}'>Редакт.</a></td></tr>");
                i++;
            }

            sb.Append("</table>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}