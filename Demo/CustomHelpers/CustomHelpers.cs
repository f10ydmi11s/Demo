using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;

namespace Demo.CustomHelpers
{
    public static class CustomHelpers
    {
        public static IHtmlString CustomImage(this HtmlHelper helper, string src, string alt)
        {
            if (helper is null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            // Build <img> tag. The parameter name must be img 
            TagBuilder tb = new TagBuilder("img");
            // Add "src" attribute
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            // Add "alt" attribute
            tb.Attributes.Add("alt", alt);
            // return MvcHtmlString. This class implements IHtmlString
            // interface. IHtmlStrings will not be html encoded.
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
        public static IHtmlString CustomFile(this HtmlHelper helper, string id)
        {
            if (helper is null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", "file");
            tb.Attributes.Add("id", id);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString GenderDropDown(this HtmlHelper helper, string name, string nameval, SelectList values, Object htmlAttributes)
        {

            //Razor html example (Create):
            //@Html.GenderDropDown("gGender", "", new SelectList(new[] { "" }), new { @class = "form-control" })
            //Razor html example (Edit):
            //@Html.GenderDropDown("gGender", Model.gGender, new SelectList(new[] { "" }), new { @class = "form-control" })

            List<SelectListItem> selItems = new List<SelectListItem>();
            if (nameval.ToLower() == "f")
            {
                selItems.Add(new SelectListItem() { Text = "Female", Value = "F", Selected = true });
                selItems.Add(new SelectListItem() { Text = "Male", Value = "M", Selected = false });
            }
            else
            {
                selItems.Add(new SelectListItem() { Text = "Female", Value = "F", Selected = false });
                selItems.Add(new SelectListItem() { Text = "Male", Value = "M", Selected = true });
            }

            return SelectExtensions.DropDownList(helper,
                                                                     name,
                                                                     selItems,
                                                                     htmlAttributes);
        }
        public static MvcHtmlString Custom_GenderDropDownFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string name, SelectList values, Object htmlAttributes)
        {

            //Razor html example (Edit):
            //@Html.Custom_GenderDropDownFor(model => model.Tblguests.gGender, "gGender", new SelectList(new List<SelectListItem> { new SelectListItem { Text = Model.Tblguests.gGender, Value = Model.Tblguests.gGender } }, "Value", "Text"), new { @class = "form-control" })

            List<SelectListItem> selItems = new List<SelectListItem>();
            int valCount = values.Count();
            string nameval = "";
            if (valCount == 1)
            {
                foreach (var item in values)
                {
                    nameval = item.Value;
                }
            }

            if (nameval.ToLower() == "f")
            {
                selItems.Add(new SelectListItem() { Text = "Female", Value = "F", Selected = true });
                selItems.Add(new SelectListItem() { Text = "Male", Value = "M", Selected = false });
            }
            else
            {
                selItems.Add(new SelectListItem() { Text = "Female", Value = "F", Selected = false });
                selItems.Add(new SelectListItem() { Text = "Male", Value = "M", Selected = true });
            }

            //return Custom_GenderDropDown(helper, expression, values, htmlAttributes);
            //return Custom_GenderDropDown(helper, expression, name, new SelectList(selItems), htmlAttributes);
            //return SelectExtensions.DropDownList(helper,
            //                                         name,
            //                                   selItems,
            //                                   htmlAttributes);
            return SelectExtensions.DropDownListFor(helper, expression,
                                               selItems,
                                               htmlAttributes);
        }

    }
    public static class HtmlUtility
    {
        public static string IsActive(this HtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // must match both
            //var returnActive = control == routeControl &&
            //                   action == routeAction;
            var returnActive = control.ToLower() == routeControl.ToLower();

            return returnActive ? "active" : "";
        }
    }



}