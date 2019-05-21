using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc.Html;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        #region AppPartial

        public static MvcHtmlString AppPartial(this HtmlHelper htmlHelper, string partialViewName, string model)
        {
            return htmlHelper.Partial(partialViewName, model);
        }

        public static MvcHtmlString AppPartial(this HtmlHelper htmlHelper, string partialViewName, object model = null)
        {
            return model != null ? htmlHelper.Partial(partialViewName, model) : htmlHelper.Partial(partialViewName);
        }

        public static MvcHtmlString AppPartial<T>(this HtmlHelper htmlHelper, string partialViewName, T model = null) where T : class, new()
        {
            return model != null ? htmlHelper.Partial(partialViewName, model) : htmlHelper.Partial(partialViewName, new T());
        }

        #endregion

        #region Button

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="icon">按钮图标</param>
        public static MvcHtmlString AppButton(this HtmlHelper htmlHelper, string icon)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Button, new AppButtonWrapper { Icon = icon });
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="text">按钮文本</param>
        /// <param name="icon">按钮图标</param>
        /// <param name="style">按钮风格</param>
        public static MvcHtmlString AppButton(this HtmlHelper htmlHelper, string text, string icon, WidgetStyle style = WidgetStyle.Default)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Button, new AppButtonWrapper { Text = text, Icon = icon, Style = style });
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="wrapper">按钮包装器(可任意组装参数)</param>
        public static MvcHtmlString AppButton(this HtmlHelper htmlHelper, AppButtonWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Button, wrapper);
        }

        #endregion

        #region SearchButton

        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="isBlockRow">是否独占一行</param>
        public static MvcHtmlString AppSearchButton(this HtmlHelper htmlHelper, bool isBlockRow = false)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.SearchButton, new AppSearchButtonWrapper { IsBlockRow = isBlockRow });
        }

        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="wrapper">搜索按钮包装器(可任意组装参数)</param>
        public static MvcHtmlString AppSearchButton(this HtmlHelper htmlHelper, AppSearchButtonWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.SearchButton, wrapper);
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="isCheckAll">是否配置为全选复选框</param>
        public static MvcHtmlString AppCheckBox(this HtmlHelper htmlHelper, bool isCheckAll = false)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Checkbox, new AppCheckBoxWrapper { IsCheckAll = isCheckAll });
        }

        /// <summary>
        /// 复选框(只针对非全选起作用)
        /// </summary>
        /// <param name="dataItemId">绑定当前行标识</param>
        public static MvcHtmlString AppCheckBox(this HtmlHelper htmlHelper, string dataItemId)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Checkbox, new AppCheckBoxWrapper { DataItemId = dataItemId, IsCheckAll = false });
        }

        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="wrapper">复选框包装器(可任意组装参数)</param>
        public static MvcHtmlString AppCheckBox(this HtmlHelper htmlHelper, AppCheckBoxWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Checkbox, wrapper);
        }

        #endregion

        #region Modal

        /// <summary>
        /// 对话框
        /// </summary>
        /// <param name="id">是否配置为全选复选框</param>
        /// <param name="headerTitle">对话框标题文字描述</param>
        /// <param name="contentViewPath">对话框内容分部页面路径</param>
        public static MvcHtmlString AppModal(this HtmlHelper htmlHelper, string id, string headerTitle, string contentViewPath)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Modal, new AppModalWrapper { Id = id, HeaderTitle = headerTitle, ContentViewPath = contentViewPath });
        }

        /// <summary>
        /// 对话框
        /// </summary>
        /// <param name="id">是否配置为全选复选框</param>
        /// <param name="headerIcon">对话框标题文字图标</param>
        /// <param name="headerTitle">对话框标题文字描述</param>
        /// <param name="contentViewPath">对话框内容分部页面路径</param>
        /// <param name="footerViewPath">对话框底部分部页面路径</param>
        public static MvcHtmlString AppModal(this HtmlHelper htmlHelper, string id, string headerIcon, string headerTitle, string contentViewPath, string footerViewPath = "")
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Modal, new AppModalWrapper { Id = id, HeaderIcon = headerIcon, HeaderTitle = headerTitle, ContentViewPath = contentViewPath, FooterViewPath = footerViewPath });
        }

        /// <summary>
        /// 对话框
        /// </summary>
        /// <param name="wrapper">对话框包装器(可任意组装参数)</param>
        public static MvcHtmlString AppModal(this HtmlHelper htmlHelper, AppModalWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppWidgetConsts.Modal, wrapper);
        }

        #endregion

        #region TextBoxQueryItem

        /// <summary>
        /// 查询项文本框(不带标签)
        /// </summary>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppTextBoxQueryItem(this HtmlHelper htmlHelper, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxQueryItem, new AppQueryItemForTextBoxWrapper { DataName = dataName });
        }

        /// <summary>
        /// 查询项文本框(带标签)
        /// </summary>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppTextBoxQueryItem(this HtmlHelper htmlHelper, string label, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxQueryItem, new AppQueryItemForTextBoxWrapper { Label = label, DataName = dataName });
        }

        /// <summary>
        /// 查询项文本框(带标签)
        /// </summary>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppTextBoxQueryItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxQueryItem, new AppQueryItemForTextBoxWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 查询项文本框(带标签)
        /// </summary>
        /// <param name="id">文本框ID</param>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="defaultValue">默认值</param>
        public static MvcHtmlString AppTextBoxQueryItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, string defaultValue = "")
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxQueryItem, new AppQueryItemForTextBoxWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, DefaultValue = defaultValue });
        }

        /// <summary>
        /// 查询项文本框(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">查询项文本框包装器</param>
        public static MvcHtmlString AppTextBoxQueryItem(this HtmlHelper htmlHelper, AppQueryItemForTextBoxWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxQueryItem, wrapper);
        }

        #endregion

        #region TextBoxFormItem

        /// <summary>
        /// 表单项文本框(带标签)
        /// </summary>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppTextBoxFormItem(this HtmlHelper htmlHelper, string label, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxFormItem, new AppFormItemForTextBoxWrapper { Label = label, DataName = dataName });
        }

        /// <summary>
        /// 表单项文本框(带标签)
        /// </summary>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppTextBoxFormItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxFormItem, new AppFormItemForTextBoxWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 表单项文本框(带标签)
        /// </summary>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="dataType">数据类型</param>
        public static MvcHtmlString AppTextBoxFormItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder, FormItemDataType dataType)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxFormItem, new AppFormItemForTextBoxWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder, DataType = dataType });
        }

        /// <summary>
        /// 表单项文本框(带标签)
        /// </summary>
        /// <param name="id">文本框ID</param>
        /// <param name="label">文本框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="dataType">数据类型</param>
        /// <param name="required">是否必填</param>
        public static MvcHtmlString AppTextBoxFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, FormItemDataType dataType = FormItemDataType.None, bool required = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxFormItem, new AppFormItemForTextBoxWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, DataType = dataType, Required = required });
        }

        /// <summary>
        /// 表单项文本框(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项文本框包装器</param>
        public static MvcHtmlString AppTextBoxFormItem(this HtmlHelper htmlHelper, AppFormItemForTextBoxWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextBoxFormItem, wrapper);
        }

        #endregion

        #region TextAreaFormItem

        /// <summary>
        /// 表单项文本域(带标签)
        /// </summary>
        /// <param name="label">文本域标签</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppTextAreaFormItem(this HtmlHelper htmlHelper, string label, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextAreaFormItem, new AppFormItemForTextAreaWrapper { Label = label, DataName = dataName });
        }

        /// <summary>
        /// 表单项文本域(带标签)
        /// </summary>
        /// <param name="label">文本域标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppTextAreaFormItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextAreaFormItem, new AppFormItemForTextAreaWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 表单项文本域(带标签)
        /// </summary>
        /// <param name="label">文本域标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="rows">默认显示的行数</param>
        /// <param name="maxChars">默认输入的最大字数限制</param>
        /// <param name="isBlockRow">是否独占一行</param>
        public static MvcHtmlString AppTextAreaFormItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder, int rows = 5, int maxChars = 500, bool isBlockRow = true)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextAreaFormItem, new AppFormItemForTextAreaWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder, Rows = rows, MaxChars = maxChars, IsBlockRow = isBlockRow });
        }

        /// <summary>
        /// 表单项文本域(带标签)
        /// </summary>
        /// <param name="id">文本域ID</param>
        /// <param name="label">文本域标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="rows">默认显示的行数</param>
        /// <param name="maxChars">默认输入的最大字数限制</param>
        /// <param name="isBlockRow">是否独占一行</param>
        /// <param name="required">是否必填</param>
        /// <param name="isReadonly">是否只读</param>
        public static MvcHtmlString AppTextAreaFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, int rows = 5, int maxChars = 500, bool isBlockRow = true, bool required = false, bool isReadonly = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextAreaFormItem, new AppFormItemForTextAreaWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, Rows = rows, MaxChars = maxChars, IsBlockRow = isBlockRow, Required = required, Readonly = isReadonly });
        }

        /// <summary>
        /// 表单项文本域(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项文本域包装器</param>
        public static MvcHtmlString AppTextAreaFormItem(this HtmlHelper htmlHelper, AppFormItemForTextAreaWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.TextAreaFormItem, wrapper);
        }

        #endregion

        #region DatePickerQueryItem

        /// <summary>
        /// 查询项日期选择器(不带标签)
        /// </summary>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppDatePickerQueryItem(this HtmlHelper htmlHelper, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerQueryItem, new AppQueryItemForDatePickerWrapper { DataName = dataName });
        }

        /// <summary>
        /// 查询项日期选择器(不带标签)
        /// </summary>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="isEditable">是否可手动输入日期</param>
        public static MvcHtmlString AppDatePickerQueryItem(this HtmlHelper htmlHelper, string dataName, bool isEditable = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerQueryItem, new AppQueryItemForDatePickerWrapper { DataName = dataName, IsEditable = isEditable });
        }

        /// <summary>
        /// 查询项日期选择器(带标签)
        /// </summary>
        /// <param name="label">日期选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="isEditable">是否可手动输入日期</param>
        public static MvcHtmlString AppDatePickerQueryItem(this HtmlHelper htmlHelper, string label, string dataName, bool isEditable = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerQueryItem, new AppQueryItemForDatePickerWrapper { Label = label, DataName = dataName, IsEditable = isEditable });
        }

        /// <summary>
        /// 查询项日期选择器(带标签)
        /// </summary>
        /// <param name="label">日期选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="isEditable">是否可手动输入日期</param>
        public static MvcHtmlString AppDatePickerQueryItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder, bool isEditable = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerQueryItem, new AppQueryItemForDatePickerWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder, IsEditable = isEditable });
        }

        /// <summary>
        /// 查询项日期选择器(带标签)
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id"></param>
        /// <param name="label"></param>
        /// <param name="dataName"></param>
        /// <param name="placeholder"></param>
        /// <param name="isEditable"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static MvcHtmlString AppDatePickerQueryItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, bool isEditable = false, string defaultValue = "")
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerQueryItem, new AppQueryItemForDatePickerWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, IsEditable = isEditable, DefaultValue = defaultValue });
        }

        /// <summary>
        /// 查询项日期选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">查询项日期选择器包装器</param>
        public static MvcHtmlString AppDatePickerQueryItem(this HtmlHelper htmlHelper, AppQueryItemForDatePickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerQueryItem, wrapper);
        }

        /// <summary>
        /// 查询项日期选择器(带标签)
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id"></param>
        /// <param name="label"></param>
        /// <param name="dataName"></param>
        /// <param name="placeholder"></param>
        /// <param name="isEditable"></param>
        /// <param name="isDatetime"></param>
        /// <param name="format"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static MvcHtmlString AppDateTimePickerQueryItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, bool isEditable = false,string format = "yyyy-mm-dd hh:ii", string defaultValue = "")
        {
            return htmlHelper.AppPartial(AppComponentConsts.DateTimePickerQueryItem, new AppQueryItemForDatePickerWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, IsEditable = isEditable, Format = format, DefaultValue = defaultValue });
        }

        #endregion

        #region SelectPickerQueryItem

        /// <summary>
        /// 查询项下拉选择器(不带标签)
        /// </summary>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppSelectPickerQueryItem(this HtmlHelper htmlHelper, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerQueryItem, new AppQueryItemForSelectPickerWrapper { DataName = dataName });
        }

        /// <summary>
        /// 查询项下拉选择器(不带标签)
        /// </summary>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        public static MvcHtmlString AppSelectPickerQueryItem(this HtmlHelper htmlHelper, string dataName, IList<SelectListItem> options)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerQueryItem, new AppQueryItemForSelectPickerWrapper { DataName = dataName, Options = options });
        }

        /// <summary>
        /// 查询项下拉选择器(带标签)
        /// </summary>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        public static MvcHtmlString AppSelectPickerQueryItem(this HtmlHelper htmlHelper, string label, string dataName, IList<SelectListItem> options)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerQueryItem, new AppQueryItemForSelectPickerWrapper { Label = label, DataName = dataName, Options = options });
        }

        /// <summary>
        /// 查询项下拉选择器(带标签)
        /// </summary>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        /// <param name="defaultItemCaption">下拉选择器默认项的显示文本</param>
        public static MvcHtmlString AppSelectPickerQueryItem(this HtmlHelper htmlHelper, string label, string dataName, IList<SelectListItem> options, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue, string defaultItemCaption = AppComponentConsts.SelectPickerDefaultCaption)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerQueryItem, new AppQueryItemForSelectPickerWrapper { Label = label, DataName = dataName, Options = options, SelectedItemValue = selectedItemValue, DefaultItemCaption = defaultItemCaption });
        }

        /// <summary>
        /// 查询项下拉选择器(带标签)
        /// </summary>
        /// <param name="id">下拉选择器ID</param>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        /// <param name="defaultItemCaption">下拉选择器默认项的显示文本</param>
        public static MvcHtmlString AppSelectPickerQueryItem(this HtmlHelper htmlHelper, string id, string label, string dataName, IList<SelectListItem> options, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue, string defaultItemCaption = AppComponentConsts.SelectPickerDefaultCaption)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerQueryItem, new AppQueryItemForSelectPickerWrapper { Id = id, Label = label, DataName = dataName, Options = options, SelectedItemValue = selectedItemValue, DefaultItemCaption = defaultItemCaption });
        }

        /// <summary>
        /// 查询项下拉选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">查询项下拉选择器包装器</param>
        public static MvcHtmlString AppSelectPickerQueryItem(this HtmlHelper htmlHelper, AppQueryItemForSelectPickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerQueryItem, wrapper);
        }

        #endregion

        #region QueryCriteriaContainer

        /// <summary>
        /// 查询组件容器
        /// </summary>
        /// <param name="viewPath">查询组件分部视图路径</param>
        public static MvcHtmlString AppQueryCriteriaContainer(this HtmlHelper htmlHelper, string viewPath)
        {
            return htmlHelper.AppPartial(AppComponentConsts.QueryCriteriaContainer, new AppQueryCriteriaViewWrapper { ViewPath = viewPath });
        }

        /// <summary>
        /// 查询组件容器
        /// </summary>
        /// <param name="id">查询组件ID</param>
        /// <param name="viewPath">查询组件分部视图路径</param>
        public static MvcHtmlString AppQueryCriteriaContainer(this HtmlHelper htmlHelper, string id, string viewPath)
        {
            return htmlHelper.AppPartial(AppComponentConsts.QueryCriteriaContainer, new AppQueryCriteriaViewWrapper { Id = id, ViewPath = viewPath });
        }

        /// <summary>
        /// 查询组件容器
        /// </summary>
        /// <param name="wrapper">查询组件容器包装器(可任意组装参数)</param>
        public static MvcHtmlString AppQueryCriteriaContainer(this HtmlHelper htmlHelper, AppQueryCriteriaViewWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.QueryCriteriaContainer, wrapper);
        }

        #endregion

        #region DatePickerFormItem

        /// <summary>
        /// 表单项日期选择器(带标签)
        /// </summary>
        /// <param name="label">日期选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppDatePickerFormItem(this HtmlHelper htmlHelper, string label, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerFormItem, new AppFormItemForDatePickerWrapper { Label = label, DataName = dataName });
        }

        /// <summary>
        /// 表单项日期选择器(带标签)
        /// </summary>
        /// <param name="label">日期选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppDatePickerFormItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerFormItem, new AppFormItemForDatePickerWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 表单项日期选择器(带标签)
        /// </summary>
        /// <param name="id">日期选择器ID</param>
        /// <param name="label">日期选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="required">是否必填</param>
        public static MvcHtmlString AppDatePickerFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, bool required = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerFormItem, new AppFormItemForDatePickerWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, Required = required });
        }

        /// <summary>
        /// 表单项日期选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">日期选择器包装器</param>
        public static MvcHtmlString AppDatePickerFormItem(this HtmlHelper htmlHelper, AppFormItemForDatePickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DatePickerFormItem, wrapper);
        }

        /// <summary>
        /// 表单项日期选择器(带标签)
        /// </summary>
        /// <param name="id">日期选择器ID</param>
        /// <param name="label">日期选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="required">是否必填</param>
        public static MvcHtmlString AppDateTimePickerFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, bool required = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DateTimePickerFormItem, new AppFormItemForDatePickerWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, Required = required });
        }
        #endregion

        #region SelectUserPickerFormItem

        /// <summary>
        /// 表单项人员选择器(带标签)
        /// </summary>
        /// <param name="label">人员选择器标签</param>
        /// <param name="dataItemId">绑定人员的id</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppSelectUserPickerFormItem(this HtmlHelper htmlHelper, string label, string dataItemId, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectUserPickerFormItem, new AppFormItemForSelectUserPickerWrapper { Label = label, DataItemId = dataItemId, DataName = dataName });
        }

        /// <summary>
        /// 表单项人员选择器(带标签)
        /// </summary>
        /// <param name="label">人员选择器标签</param>
        /// <param name="dataItemId">绑定人员的id</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppSelectUserPickerFormItem(this HtmlHelper htmlHelper, string label, string dataItemId, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectUserPickerFormItem, new AppFormItemForSelectUserPickerWrapper { Label = label, DataItemId = dataItemId, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 表单项人员选择器(带标签)
        /// </summary>
        /// <param name="id">人员选择器ID</param>
        /// <param name="label">人员选择器标签</param>
        /// <param name="dataItemId">绑定人员的id</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="required">是否必填</param>
        public static MvcHtmlString AppSelectUserPickerFormItem(this HtmlHelper htmlHelper, string id, string label, string dataItemId, string dataName, string placeholder, bool required = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectUserPickerFormItem, new AppFormItemForSelectUserPickerWrapper { Id = id, DataItemId = dataItemId, Label = label, DataName = dataName, PlaceHolder = placeholder, Required = required });
        }

        /// <summary>
        /// 表单项人员选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">人员选择器包装器</param>
        public static MvcHtmlString AppSelectUserPickerFormItem(this HtmlHelper htmlHelper, AppFormItemForSelectUserPickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectUserPickerFormItem, wrapper);
        }

        #endregion

        #region SelectTagPickerFormItem

        /// <summary>
        /// 表单项单个标签选择器(带标签)
        /// </summary>
        /// <param name="label">单个标签选择器标签</param>
        /// <param name="dataItemId">绑定供应商的id</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppSelectTagPickerFormItem(this HtmlHelper htmlHelper, string label, string dataItemId, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectTagPickerFormItem, new AppFormItemForSelectTagPickerWrapper { Label = label, DataItemId = dataItemId, DataName = dataName });
        }

        /// <summary>
        /// 表单项单个标签选择器(带标签)
        /// </summary>
        /// <param name="label">单个标签选择器标签</param>
        /// <param name="dataItemId">绑定供应商的id</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppSelectTagPickerFormItem(this HtmlHelper htmlHelper, string label, string dataItemId, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectTagPickerFormItem, new AppFormItemForSelectTagPickerWrapper { Label = label, DataItemId = dataItemId, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 表单项单个标签选择器(带标签)
        /// </summary>
        /// <param name="id">单个标签选择器ID</param>
        /// <param name="label">单个标签选择器标签</param>
        /// <param name="dataItemId">绑定供应商的id</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="required">是否必填</param>
        public static MvcHtmlString AppSelectTagPickerFormItem(this HtmlHelper htmlHelper, string id, string label, string dataItemId, string dataName, string placeholder, bool required = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectTagPickerFormItem, new AppFormItemForSelectTagPickerWrapper { Id = id, DataItemId = dataItemId, Label = label, DataName = dataName, PlaceHolder = placeholder, Required = required });
        }

        /// <summary>
        /// 表单项单个标签选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">单个标签选择器包装器</param>
        public static MvcHtmlString AppSelectTagPickerFormItem(this HtmlHelper htmlHelper, AppFormItemForSelectTagPickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectTagPickerFormItem, wrapper);
        }

        #endregion

        #region SelectPickerFormItem

        /// <summary>
        /// 表单项下拉选择器(带标签)
        /// </summary>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        public static MvcHtmlString AppSelectPickerFormItem(this HtmlHelper htmlHelper, string label, string dataName, IList<SelectListItem> options)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerFormItem, new AppFormItemForSelectPickerWrapper { Label = label, DataName = dataName, Options = options });
        }

        /// <summary>
        /// 表单项下拉选择器(带标签)
        /// </summary>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        /// <param name="required">是否是必选的</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        /// <param name="defaultItemCaption">下拉选择器默认项的显示文本</param>
        public static MvcHtmlString AppSelectPickerFormItem(this HtmlHelper htmlHelper, string label, string dataName, IList<SelectListItem> options, bool required = false, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue, string defaultItemCaption = AppComponentConsts.SelectPickerDefaultCaption)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerFormItem, new AppFormItemForSelectPickerWrapper { Label = label, DataName = dataName, Options = options, Required = required, SelectedItemValue = selectedItemValue, DefaultItemCaption = defaultItemCaption });
        }

        /// <summary>
        /// 表单项下拉选择器(带标签)
        /// </summary>
        /// <param name="id">下拉选择器ID</param>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        /// <param name="required">是否是必选的</param>
        /// <param name="isReadonly">是否是只读的</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        /// <param name="defaultItemCaption">下拉选择器默认项的显示文本</param>
        public static MvcHtmlString AppSelectPickerFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, IList<SelectListItem> options, bool required = false, bool isReadonly = false, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue, string defaultItemCaption = AppComponentConsts.SelectPickerDefaultCaption)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerFormItem, new AppFormItemForSelectPickerWrapper { Id = id, Label = label, DataName = dataName, Options = options, Required = required, Readonly = isReadonly, SelectedItemValue = selectedItemValue, DefaultItemCaption = defaultItemCaption });
        }

        /// <summary>
        /// 表单项下拉选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项下拉选择器包装器</param>
        public static MvcHtmlString AppSelectPickerFormItem(this HtmlHelper htmlHelper, AppFormItemForSelectPickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerFormItem, wrapper);
        }

        #endregion

        #region SelectPickerExFormItem

        /// <summary>
        /// 表单项下拉选择器(带标签)
        /// </summary>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        public static MvcHtmlString AppSelectPickerExFormItem(this HtmlHelper htmlHelper, string label, string dataName, IList<SelectListItem> options)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerExFormItem, new AppFormItemForSelectPickerWrapper { Label = label, DataName = dataName, Options = options });
        }

        /// <summary>
        /// 表单项下拉选择器(带标签)
        /// </summary>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        /// <param name="required">是否是必选的</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        /// <param name="defaultItemCaption">下拉选择器默认项的显示文本</param>
        public static MvcHtmlString AppSelectPickerExFormItem(this HtmlHelper htmlHelper, string label, string dataName, IList<SelectListItem> options, bool required = false, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue, string defaultItemCaption = AppComponentConsts.SelectPickerDefaultCaption)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerExFormItem, new AppFormItemForSelectPickerWrapper { Label = label, DataName = dataName, Options = options, Required = required, SelectedItemValue = selectedItemValue, DefaultItemCaption = defaultItemCaption });
        }

        /// <summary>
        /// 表单项下拉选择器(带标签)
        /// </summary>
        /// <param name="id">下拉选择器ID</param>
        /// <param name="label">下拉选择器标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="options">下拉选择器选项列表</param>
        /// <param name="required">是否是必选的</param>
        /// <param name="isReadonly">是否是只读的</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        /// <param name="defaultItemCaption">下拉选择器默认项的显示文本</param>
        public static MvcHtmlString AppSelectPickerExFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, IList<SelectListItem> options, bool required = false, bool isReadonly = false, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue, string defaultItemCaption = AppComponentConsts.SelectPickerDefaultCaption)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerExFormItem, new AppFormItemForSelectPickerWrapper { Id = id, Label = label, DataName = dataName, Options = options, Required = required, Readonly = isReadonly, SelectedItemValue = selectedItemValue, DefaultItemCaption = defaultItemCaption });
        }

        /// <summary>
        /// 表单项下拉选择器(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项下拉选择器包装器</param>
        public static MvcHtmlString AppSelectPickerExFormItem(this HtmlHelper htmlHelper, AppFormItemForSelectPickerWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.SelectPickerExFormItem, wrapper);
        }

        #endregion

        #region CheckboxFormItem

        /// <summary>
        /// 表单项复选框(带标签)
        /// </summary>
        /// <param name="label">复选框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppCheckboxFormItem(this HtmlHelper htmlHelper, string label, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.CheckBoxFormItem, new AppFormItemForCheckBoxWrapper { Label = label, DataName = dataName });
        }

        /// <summary>
        /// 表单项复选框(带标签)
        /// </summary>
        /// <param name="id">复选框ID</param>
        /// <param name="label">复选框标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="isChecked">是否选中</param>
        /// <param name="required">是否必填</param>
        public static MvcHtmlString AppCheckboxFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, bool isChecked = false, bool required = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.CheckBoxFormItem, new AppFormItemForCheckBoxWrapper { Id = id, Label = label, DataName = dataName, Checked = isChecked, Required = required });
        }

        /// <summary>
        /// 表单项复选框(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">人员选择器包装器</param>
        public static MvcHtmlString AppCheckboxFormItem(this HtmlHelper htmlHelper, AppFormItemForCheckBoxWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.CheckBoxFormItem, wrapper);
        }

        #endregion

        #region RadioButtonListFormItem

        /// <summary>
        /// 表单项单选按钮组(带标签)
        /// </summary>
        /// <param name="label">单选按钮组标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="groupName">单选按钮组的类别名</param>
        /// <param name="items">单选按钮组选项列表</param>
        public static MvcHtmlString AppRadioButtonListFormItem(this HtmlHelper htmlHelper, string label, string dataName, string groupName, IList<SelectListItem> items)
        {
            return htmlHelper.AppPartial(AppComponentConsts.RadioButtonListFormItem, new AppFormItemForRadioButtonListWrapper { Label = label, DataName = dataName, GroupName = groupName, Items = items });
        }

        /// <summary>
        /// 表单项单选按钮组(带标签)
        /// </summary>
        /// <param name="label">单选按钮组标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="groupName">单选按钮组的类别名</param>
        /// <param name="items">单选按钮组选项列表</param>
        /// <param name="required">是否是必选的</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        public static MvcHtmlString AppRadioButtonListFormItem(this HtmlHelper htmlHelper, string label, string dataName, string groupName, IList<SelectListItem> items, bool required = false, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue)
        {
            return htmlHelper.AppPartial(AppComponentConsts.RadioButtonListFormItem, new AppFormItemForRadioButtonListWrapper { Label = label, DataName = dataName, GroupName = groupName, Items = items, Required = required, SelectedItemValue = selectedItemValue });
        }

        /// <summary>
        /// 表单项单选按钮组(带标签)
        /// </summary>
        /// <param name="id">单选按钮组ID</param>
        /// <param name="label">单选按钮组标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="groupName">单选按钮组的类别名</param>
        /// <param name="items">单选按钮组选项列表</param>
        /// <param name="required">是否是必选的</param>
        /// <param name="isReadonly">是否是只读的</param>
        /// <param name="selectedItemValue">默认选中项的值</param>
        public static MvcHtmlString AppRadioButtonListFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string groupName, IList<SelectListItem> items, bool required = false, bool isReadonly = false, string selectedItemValue = AppComponentConsts.SelectPickerDefaultSelectedValue)
        {
            return htmlHelper.AppPartial(AppComponentConsts.RadioButtonListFormItem, new AppFormItemForRadioButtonListWrapper { Id = id, Label = label, DataName = dataName, GroupName = groupName, Items = items, Required = required, Readonly = isReadonly, SelectedItemValue = selectedItemValue });
        }

        /// <summary>
        /// 表单项单选按钮组(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项单选按钮组包装器</param>
        public static MvcHtmlString AppRadioButtonListFormItem(this HtmlHelper htmlHelper, AppFormItemForRadioButtonListWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.RadioButtonListFormItem, wrapper);
        }

        #endregion

        #region UploadAttachmentFormItem

        /// <summary>
        /// 表单项附件上传组件(带标签)
        /// </summary>
        /// <param name="label">附件上传组件标签</param>
        /// <param name="dataName">绑定数据列名</param>
        public static MvcHtmlString AppUploadAttachmentFormItem(this HtmlHelper htmlHelper, string label, string dataName)
        {
            return htmlHelper.AppPartial(AppComponentConsts.UploadAttachmentFormItem, new AppFormItemForUploadAttachmentWrapper { Label = label, DataName = dataName });
        }

        /// <summary>
        /// 表单项附件上传组件(带标签)
        /// </summary>
        /// <param name="label">附件上传组件标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        public static MvcHtmlString AppUploadAttachmentFormItem(this HtmlHelper htmlHelper, string label, string dataName, string placeholder)
        {
            return htmlHelper.AppPartial(AppComponentConsts.UploadAttachmentFormItem, new AppFormItemForUploadAttachmentWrapper { Label = label, DataName = dataName, PlaceHolder = placeholder });
        }

        /// <summary>
        /// 表单项附件上传组件(带标签)
        /// </summary>
        /// <param name="id">附件上传组件ID</param>
        /// <param name="label">附件上传组件标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="placeholder">提示符</param>
        /// <param name="isBlockRow">是否独占一行</param>
        /// <param name="required">是否必填</param>
        /// <param name="isReadonly">是否只读</param>
        public static MvcHtmlString AppUploadAttachmentFormItem(this HtmlHelper htmlHelper, string id, string label, string dataName, string placeholder, bool isBlockRow = true, bool required = false, bool isReadonly = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.UploadAttachmentFormItem, new AppFormItemForUploadAttachmentWrapper { Id = id, Label = label, DataName = dataName, PlaceHolder = placeholder, IsBlockRow = isBlockRow, Required = required, Readonly = isReadonly });
        }

        /// <summary>
        /// 表单项附件上传组件(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项附件上传组件包装器</param>
        public static MvcHtmlString AppUploadAttachmentFormItem(this HtmlHelper htmlHelper, AppFormItemForUploadAttachmentWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.UploadAttachmentFormItem, wrapper);
        }

        #endregion

        #region CustomComponentFormItem

        /// <summary>
        /// 表单项自定义内容组件(带标签)
        /// </summary>
        /// <param name="label">自定义内容组件标签</param>
        /// <param name="dataName">绑定数据列名</param>
        /// <param name="viewPath">自定义内容的分布页路径</param>
        /// <param name="isBlockRow">是否独占一行</param>
        public static MvcHtmlString AppCustomComponentFormItem(this HtmlHelper htmlHelper, string label, string dataName, string viewPath, bool isBlockRow = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.CustomComponentFormItem, new AppFormItemForCustomComponentWrapper { Label = label, DataName = dataName, CustomViewPath = viewPath, IsBlockRow = isBlockRow });
        }

        /// <summary>
        /// 表单项自定义内容组件(可任意组装参数)
        /// </summary>
        /// <param name="wrapper">表单项自定义内容组件包装器</param>
        public static MvcHtmlString AppCustomComponentFormItem(this HtmlHelper htmlHelper, AppFormItemForCustomComponentWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.CustomComponentFormItem, wrapper);
        }

        #endregion

        #region DataTableContainer

        /// <summary>
        /// 表格组件容器
        /// </summary>
        /// <param name="id">表格组件ID</param>
        /// <param name="headerViewPath">表头分部视图路径</param>
        /// <param name="hasPager">是否有分页控件(默认有)</param>
        public static MvcHtmlString AppDataTableContainer(this HtmlHelper htmlHelper, string id, string headerViewPath, bool hasPager = true)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataTableContainer, new AppDataTableContainerViewWrapper { Id = id, DataHeaderViewPath = headerViewPath, HasPager = hasPager });
        }

        /// <summary>
        /// 表格组件容器
        /// </summary>
        /// <param name="id">表格组件ID</param>
        /// <param name="headerViewPath">表头分部视图路径</param>
        /// <param name="settings">固定表头配置</param>
        /// <param name="hasPager">是否有分页控件(默认有)</param>
        public static MvcHtmlString AppDataTableContainer(this HtmlHelper htmlHelper, string id, string headerViewPath, FixiableTableSettings settings, bool hasPager = true)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataTableContainer, new AppDataTableContainerViewWrapper { Id = id, DataHeaderViewPath = headerViewPath, FixiableSettings = settings, HasPager = hasPager });
        }

        /// <summary>
        /// 表格组件容器
        /// </summary>
        /// <param name="id">表格组件ID</param>
        /// <param name="headerViewPath">表头分部视图路径</param>
        /// <param name="actionViewPath">操作按钮分部视图路径</param>
        /// <param name="hasPager">是否有分页控件(默认有)</param>
        /// <param name="pagerId">分页控件Id</param>
        public static MvcHtmlString AppDataTableContainer(this HtmlHelper htmlHelper, string id, string headerViewPath, string actionViewPath, bool hasPager = true, string pagerId = "")
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataTableContainer, new AppDataTableContainerViewWrapper { Id = id, DataHeaderViewPath = headerViewPath, DataActionViewPath = actionViewPath, HasPager = hasPager, PagerId = pagerId });
        }

        /// <summary>
        /// 表格组件容器
        /// </summary>
        /// <param name="id">表格组件ID</param>
        /// <param name="headerViewPath">表头分部视图路径</param>
        /// <param name="actionViewPath">操作按钮分部视图路径</param>
        /// <param name="settings">固定表头配置</param>
        /// <param name="hasPager">是否有分页控件(默认有)</param>
        /// <param name="pagerId">分页控件Id</param>
        public static MvcHtmlString AppDataTableContainer(this HtmlHelper htmlHelper, string id, string headerViewPath, string actionViewPath, FixiableTableSettings settings, bool hasPager = true, string pagerId = "")
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataTableContainer, new AppDataTableContainerViewWrapper { Id = id, DataHeaderViewPath = headerViewPath, DataActionViewPath = actionViewPath, FixiableSettings = settings, HasPager = hasPager, PagerId = pagerId });
        }

        /// <summary>
        /// 表格组件容器
        /// </summary>
        /// <param name="wrapper">表格组件容器包装器(可任意组装参数)</param>
        public static MvcHtmlString AppDataTableContainer(this HtmlHelper htmlHelper, AppDataTableContainerViewWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataTableContainer, wrapper);
        }

        #endregion

        #region DataFormContainer

        /// <summary>
        /// 表单组件容器
        /// </summary>
        /// <param name="id">表单组件ID</param>
        /// <param name="name">表单组件名称</param>
        /// <param name="icon">表单组件图标</param>
        /// <param name="includeForm">是否包含内嵌表单</param>
        public static MvcHtmlString AppDataFormContainer(this HtmlHelper htmlHelper, string id, string name, string icon = "plus", bool includeForm = false)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataFormContainer, new AppDataFormContainerViewWrapper { Id = id, Name = name, Icon = icon, IncludeForm = includeForm });
        }

        /// <summary>
        /// 表单组件容器
        /// </summary>
        /// <param name="id">表单组件ID</param>
        /// <param name="name">表单组件名称</param>
        /// <param name="icon">表单组件图标</param>
        /// <param name="sections">表单内部区域分块</param>
        public static MvcHtmlString AppDataFormContainer(this HtmlHelper htmlHelper, string id, string name, string icon, IList<AppDataFormSection> sections)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataFormContainer, new AppDataFormContainerViewWrapper { Id = id, Name = name, Icon = icon, Sections = sections, IncludeForm = true });
        }

        /// <summary>
        /// 表单组件容器
        /// </summary>
        /// <param name="wrapper">表格组件容器包装器(可任意组装参数)</param>
        public static MvcHtmlString AppDataFormContainer(this HtmlHelper htmlHelper, AppDataFormContainerViewWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataFormContainer, wrapper);
        }

        #endregion

        #region DataFormSection

        /// <summary>
        /// 表单区段组件
        /// </summary>
        /// <param name="name">表单区段名称</param>
        /// <param name="isTitle">是否用于表单标题区域</param>
        /// <param name="style">表单区段风格</param>
        public static MvcHtmlString AppDataFormSection(this HtmlHelper htmlHelper, string name, bool isTitle = false, WidgetStyle style = WidgetStyle.Sky)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataFormSection, new AppDataFormSectionViewWrapper { Name = name, IsTitle = isTitle, Style = style });
        }

        /// <summary>
        /// 表单区段组件
        /// </summary>
        /// <param name="wrapper">表格组件容器包装器(可任意组装参数)</param>
        public static MvcHtmlString AppDataFormSection(this HtmlHelper htmlHelper, AppDataFormSectionViewWrapper wrapper)
        {
            return htmlHelper.AppPartial(AppComponentConsts.DataFormSection, wrapper);
        }

        #endregion

        #region Workflow

        /// <summary>
        /// 工作流工具栏组件
        /// </summary>
        public static MvcHtmlString AppWorkflowToolbar(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial(AppComponentConsts.WorkflowToolbar);
        }

        /// <summary>
        /// 工作流节点组件
        /// </summary>
        public static MvcHtmlString AppWorkflowProcesses(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial(AppComponentConsts.WorkflowProcesses);
        }

        /// <summary>
        /// 工作流审批组件
        /// </summary>
        public static MvcHtmlString AppWorkflowApproval(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial(AppComponentConsts.WorkflowApproval);
        }

        /// <summary>
        /// 工作流顺序审批组件
        /// </summary>
        public static MvcHtmlString AppWorkflowSortedApproval(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial(AppComponentConsts.WorkflowSortedApproval);
        }

        #endregion
    }

    public static partial class LanguageHelper
    {
        #region MappingLang

        /// <summary>
        /// 多语言映射配置
        /// </summary>
        public static IDictionary<AssetLocaleIdentity, LanguageMappings> MappingLang(string languageId)
        {
            var localesItems = new Dictionary<AssetLocaleIdentity, LanguageMappings>();
            var localesConfig = new Dictionary<AssetLocaleIdentity, IList<LanguageMappings>>
            {
                {
                    AssetLocaleIdentity.Bootstrap_DateTime,
                    new List<LanguageMappings>
                    {
                        new LanguageMappings { LanguageId = "1033", LanguageName = "en", JavascriptClientLocale = "en" },
                        new LanguageMappings { LanguageId = "2052", LanguageName = "zh-CN", JavascriptClientLocale = "zh-CN" }
                    }
                },
                {
                    AssetLocaleIdentity.Bootstrap_Select,
                    new List<LanguageMappings>
                    {
                        new LanguageMappings { LanguageId = "1033", LanguageName = "en_US" },
                        new LanguageMappings { LanguageId = "2052", LanguageName = "zh_CN" }
                    }
                },
                {
                    AssetLocaleIdentity.JQuery_Uploader,
                    new List<LanguageMappings>
                    {
                        new LanguageMappings { LanguageId = "1033", LanguageName = "en" },
                        new LanguageMappings { LanguageId = "2052", LanguageName = "zh" }
                    }
                },
                {
                    AssetLocaleIdentity.JQuery_Pager,
                    new List<LanguageMappings>
                    {
                        new LanguageMappings { LanguageId = "1033", LanguageName = "en", JavascriptClientLocale = "en" },
                        new LanguageMappings { LanguageId = "2052", LanguageName = "zh", JavascriptClientLocale = "zh" }
                    }
                },
                {
                    AssetLocaleIdentity.M2,
                    new List<LanguageMappings>
                    {
                        new LanguageMappings { LanguageId = "1033", LanguageName = "en-US" },
                        new LanguageMappings { LanguageId = "2052", LanguageName = "zh-CN" }
                    }
                }
            };

            foreach (var item in localesConfig)
            {
                var mapping = item.Value.FirstOrDefault(l => l.LanguageId == languageId);
                if (mapping == null)
                {
                    mapping = item.Value.FirstOrDefault();
                }
                localesItems.Add(item.Key, mapping);
            }

            return localesItems;
        }

        #endregion
    }

    public enum AssetLocaleIdentity
    {
        Bootstrap_DateTime,
        Bootstrap_Select,
        JQuery_Uploader,
        JQuery_Pager,
        M2
    }

    public class LanguageMappings
    {
        /// <summary>
        /// 当前系统使用的语言编号
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        /// 多语言脚本文件的名称(仅Language部分)
        /// </summary>
        public string LanguageName { get; set; }

        /// <summary>
        /// JS客户端使用的语言key
        /// </summary>
        public string JavascriptClientLocale { get; set; }
    }

    public static class EnumExtensions
    {
        public static string ToLower(this WidgetStyle style)
        {
            return Enum.GetName(style.GetType(), style).ToLower();
        }

        public static string ToLower(this WidgetSize size)
        {
            return Enum.GetName(size.GetType(), size).ToLower();
        }
    }
}