using System.Collections.Generic;

namespace System.Web.Mvc
{
    #region QueryCriteria Component

    public class AppQueryCriteriaViewWrapper : AppViewWrapperBase
    {
        public AppQueryCriteriaViewWrapper()
        {
            this.Id = "query-search-filter";
        }

        /// <summary>
        /// 查询组件的标题
        /// </summary>
        public string Title { get; set; } = AppComponentConsts.QueryCriteriaDefaultTitle;

        /// <summary>
        /// 查询组件分部视图路径
        /// </summary>
        public string ViewPath { get; set; }
    }

    #endregion

    #region Container Component

    public class AppDataFormContainerViewWrapper : AppViewWrapperBase
    {
        public AppDataFormContainerViewWrapper()
        {
            this.Id = "data-form-container";
        }

        /// <summary>
        /// 容器名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 容器图标
        /// </summary>
        public string Icon { get; set; } = "plus";

        /// <summary>
        /// 是否包含内嵌表单
        /// </summary>
        public bool IncludeForm { get; set; } = false;

        /// <summary>
        /// 表单内部区域分块
        /// </summary>
        public IList<AppDataFormSection> Sections { get; set; } = new List<AppDataFormSection>();
    }

    public class AppDataFormSection
    {
        /// <summary>
        /// 表单内部区域标识
        /// </summary>
        public string SectionId { get; set; }

        /// <summary>
        /// 表单内部区域分布视图地址
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// 表单区域的只读属性
        /// </summary>
        public bool Readonly { get; set; } = false;

        /// <summary>
        /// 表单数据所属的作用域
        /// </summary>
        public string DataScope { get; set; }
    }

    public class AppDataFormSectionViewWrapper : AppViewWrapperBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否用于标题区域
        /// </summary>
        public bool IsTitle { get; set; } = false;

        /// <summary>
        /// 表单区域风格
        /// </summary>
        public WidgetStyle Style { get; set; } = WidgetStyle.Sky;
    }

    public class AppDataTableContainerViewWrapper : AppViewWrapperBase
    {
        public AppDataTableContainerViewWrapper()
        {
            this.Id = "data-item-list";
        }
        /// <summary>
        /// 显示操作按钮
        /// </summary>
        public bool ShowActions { get; set; } = true;
        /// <summary>
        /// 表格容器的ID标识
        /// </summary>
        public string ContainerId { get; set; }

        /// <summary>
        /// 是否有分页控件(默认有)
        /// </summary>
        public bool HasPager { get; set; } = true;

        /// <summary>
        /// 分页控件Id
        /// </summary>
        public string PagerId { get; set; } = "data-list-pager";

        /// <summary>
        /// 操作按钮分部视图路径
        /// </summary>
        public string DataActionViewPath { get; set; }

        /// <summary>
        /// 表头分部视图路径
        /// </summary>
        public string DataHeaderViewPath { get; set; }

        /// <summary>
        /// 表尾分部视图路径
        /// </summary>
        public string DataFooterViewPath { get; set; }

        /// <summary>
        /// 是否支持滚动的Table, 默认不支持
        /// </summary>
        public bool IsScrollable { get; set; } = false;

        /// <summary>
        /// 表头边框风格
        /// </summary>
        public WidgetStyle HeaderBorderStyle { get; set; } = WidgetStyle.PaleGreen;

        /// <summary>
        /// 固定表头配置项
        /// </summary>
        public FixiableTableSettings FixiableSettings { get; set; }
    }

    public class FixiableTableSettings
    {
        /// <summary>
        /// 固定表头的标识ID
        /// </summary>
        public string Id { get; set; } = "data-fixed";

        /// <summary>
        /// 固定表头的百分比
        /// </summary>
        public int Percent { get; set; } = 10;

        /// <summary>
        /// 固定表头分部视图路径
        /// </summary>
        public string DataHeaderViewPath { get; set; }
    }

    #endregion

    #region QueryItem Component

    public class AppQueryComponentWrapper : AppViewWrapperBase
    {
        /// <summary>
        /// 查询项标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 标签项是否需要换行显示(针对标签太长)
        /// </summary>
        public bool IsLabelWrap { get; set; }

        /// <summary>
        /// 绑定数据列名
        /// </summary>
        public string DataName { get; set; }
    }

    public class AppQueryItemForTextBoxWrapper : AppQueryComponentWrapper
    {
        /// <summary>
        /// 提示语
        /// </summary>
        public string PlaceHolder { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
    }

    public class AppQueryItemForDatePickerWrapper : AppQueryItemForTextBoxWrapper
    {
        /// <summary>
        /// 是否可手动输入日期
        /// </summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 显示格式
        /// </summary>
        public string Format { get; set; } = "yyyy-mm-dd";
    }

    public class AppQueryItemForSelectPickerWrapper : AppQueryComponentWrapper
    {
        /// <summary>
        /// 下拉框默认项的显示文本
        /// </summary>
        public string DefaultItemCaption { get; set; } = AppComponentConsts.SelectPickerDefaultCaption;


        /// <summary>
        /// 下拉框默认项的显示值
        /// </summary>
        public string DefaultItemValue { get; set; } = AppComponentConsts.SelectPickerDefaultSelectedValue;

        /// <summary>
        /// 选中项绑定的文本名称
        /// </summary>
        public string SelectedItemDataName { get; set; } = "";

        /// <summary>
        /// 选中项的值
        /// </summary>
        public string SelectedItemValue { get; set; } = AppComponentConsts.SelectPickerDefaultSelectedValue;

        /// <summary>
        /// 数据映射对应的值属性
        /// </summary>
        public string DataMappingValueField { get; set; }

        /// <summary>
        /// 数据映射对应的文本属性
        /// </summary>
        public string DataMappingTextField { get; set; }

        /// <summary>
        /// 是否显示默认选项
        /// </summary>
        public bool ShowDefaultOption { get; set; } = true;

        /// <summary>
        /// 下拉选择器选项列表(同步数据源)
        /// </summary>
        public IList<SelectListItem> Options { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// html title 标签
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 动态异步数据源(来自JQ Tmpl)
        /// </summary>
        public string DataSource { get; set; } = "[]";
    }

    #endregion

    #region FormItem Component

    public class AppFormComponentWrapper : AppViewWrapperBase
    {
        /// <summary>
        /// 表单项标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 标签的占比（默认为3）
        /// </summary>
        public int LabelPortion { get; set; } = 3;

        /// <summary>
        /// 当组件独占一行时是否保留右侧间隙
        /// </summary>
        public bool KeepBlockSpace { get; set; } = true;

        /// <summary>
        /// 表单项标签样式
        /// </summary>
        public string LabelCssClass { get; set; }

        /// <summary>
        /// 绑定数据列名
        /// </summary>
        public string DataName { get; set; }

        /// <summary>
        /// 是否为只读
        /// </summary>
        public bool Readonly { get; set; } = false;

        /// <summary>
        /// 是否继承父容器的只读策略
        /// </summary>
        public bool InheritedReadonly { get; set; } = true;

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// 是否为必填
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        /// 工具提示
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// 是否独占一行
        /// </summary>
        public bool IsBlockRow { get; set; } = false;

        protected string GetLastLevelDataName()
        {
            string result = this.DataName;

            if (string.IsNullOrEmpty(this.DataName) == false)
            {
                string[] parts = this.DataName.Split('.');

                if (parts.Length > 0)
                    result = parts[parts.Length - 1];
            }

            return result;
        }

        public int GetComponentWidth()
        {
            var portion = string.IsNullOrEmpty(this.Label) ? 0 : this.LabelPortion;
            return (this.IsBlockRow && !this.KeepBlockSpace ? 12 : 11) - portion;
        }
    }

    public class AppFormItemForTextBoxWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 禁止任何操作，包含拷贝粘贴
        /// </summary>
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// 提示语
        /// </summary>
        public string PlaceHolder { get; set; }

        /// <summary>
        /// 相关数据项值
        /// </summary>
        public string DataItemId { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public FormItemDataType DataType { get; set; } = FormItemDataType.None;
    }

    public class AppFormItemForDatePickerWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 是否允许日期手动输入
        /// </summary>
        public bool IsEditable { get; set; } = false;

        /// <summary>
        /// 提示语
        /// </summary>
        public string PlaceHolder { get; set; }
    }

    public class AppFormItemForTextAreaWrapper : AppFormComponentWrapper
    {
        public AppFormItemForTextAreaWrapper()
        {
            this.IsBlockRow = true;
        }

        /// <summary>
        /// 提示语
        /// </summary>
        public string PlaceHolder { get; set; }

        /// <summary>
        /// 默认显示的行数
        /// </summary>
        public int Rows { get; set; } = 5;

        /// <summary>
        /// 默认输入的最大字数限制
        /// </summary>
        public int MaxChars { get; set; } = 500;
    }

    public class AppFormItemForSelectItemPickerWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 需要绑定的项Id
        /// </summary>
        public string DataItemId { get; set; }

        /// <summary>
        /// 最大选取的标签数
        /// </summary>
        public int MaxTags { get; set; }

        /// <summary>
        /// 允许自由输入
        /// </summary>
        public bool AllowFreeInput { get; set; } = true;

        /// <summary>
        /// 绑定数据源的值字段
        /// </summary>
        public virtual string DataItemValue { get; set; }

        /// <summary>
        /// 绑定数据源的显示文本字段
        /// </summary>
        public virtual string DataItemText { get; set; }

        /// <summary>
        /// 显示下拉选择项的字段(默认为DataItemText)
        /// </summary>
        public virtual string DataOptionText { get; set; }

        /// <summary>
        /// 提示语
        /// </summary>
        public string PlaceHolder { get; set; }

        /// <summary>
        /// 标签的类型（如: select-user, select-vendor）
        /// </summary>
        public string TagsType { get; set; }

        /// <summary>
        /// 请求的API地址
        /// </summary>
        public string QueryApiUrl { get; set; }

        /// <summary>
        /// 请求的API参数
        /// </summary>
        public virtual string QueryParams { get; set; } = string.Empty;

        /// <summary>
        /// 请求的API额外参数(动态绑定)
        /// </summary>
        public virtual string OtherParams { get; set; } = string.Empty;

        /// <summary>
        /// 执行API查询的关键字长度阈值(默认为1)
        /// </summary>
        public int QueryThreshold { get; set; } = 2;

        /// <summary>
        /// 查询结果的数量限制(默认为5)
        /// </summary>
        public int QueryResultLimit { get; set; } = 15;

        /// <summary>
        /// 本地数据源(Json文件)
        /// </summary>
        public string LocalDataFile { get; set; }

        /// <summary>
        /// 数据源序列化JSON
        /// </summary>
        public virtual string JsonData { get; set; }

        /// <summary>
        /// 删除提示
        /// </summary>
        public virtual string RemoveTip { get; set; }
    }

    public class AppFormItemForSelectUserPickerWrapper : AppFormItemForSelectItemPickerWrapper
    {
        public AppFormItemForSelectUserPickerWrapper()
        {
            this.PlaceHolder = "Add More Users...";
            this.RemoveTip = "至少需要选择一名人员，不能删除！";
            this.TagsType = "select-user";
        }

        /// <summary>
        /// 数据区分类别字段
        /// </summary>
        public string DataFilterField { get; set; } = "objectType";

        /// <summary>
        /// 显示提示信息字段
        /// </summary>
        public string DataTooltipField { get; set; } = "description";

        public override string DataItemValue
        {
            get
            {
                string result = base.DataItemValue;

                if (string.IsNullOrEmpty(result))
                    result = "id";

                return result;
            }
            set
            {
                base.DataItemValue = value;
            }
        }

        public override string DataItemText
        {
            get
            {
                string result = base.DataItemText;

                if (string.IsNullOrEmpty(result))
                    result = "displayName";

                return result;
            }
            set
            {
                base.DataItemText = value;
            }
        }

        public override string JsonData
        {
            get
            {
                string result = base.JsonData;

                if (string.IsNullOrEmpty(result))
                    result = base.GetLastLevelDataName() + "JsonData";

                return result;
            }
            set
            {
                base.JsonData = value;
            }
        }
    }

    public class AppFormItemForSelectTagPickerWrapper : AppFormItemForSelectItemPickerWrapper
    {
        public AppFormItemForSelectTagPickerWrapper()
        {
            this.MaxTags = 1;
            this.PlaceHolder = "Add Tag...";
            this.RemoveTip = "至少需要选择一个供应商，不能删除！";
            this.TagsType = "select-tag";
        }
    }

    public class AppFormItemForSelectPickerWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 下拉框默认项的显示文本
        /// </summary>
        public string DefaultItemCaption { get; set; } = AppComponentConsts.SelectPickerDefaultCaption;

        /// <summary>
        /// 下拉框默认项的显示值
        /// </summary>
        public string DefaultItemValue { get; set; } = AppComponentConsts.SelectPickerDefaultSelectedValue;

        /// <summary>
        /// 选中项绑定的文本名称
        /// </summary>
        public string SelectedItemDataName { get; set; } = "";

        /// <summary>
        /// 选中项的值
        /// </summary>
        public string SelectedItemValue { get; set; } = AppComponentConsts.SelectPickerDefaultSelectedValue;

        /// <summary>
        /// 数据映射对应的值属性
        /// </summary>
        public string DataMappingValueField { get; set; }

        /// <summary>
        /// 数据映射对应的文本属性
        /// </summary>
        public string DataMappingTextField { get; set; }

        /// <summary>
        /// 是否显示默认选项
        /// </summary>
        public bool ShowDefaultOption { get; set; } = true;

        /// <summary>
        /// 下拉选择器选项列表(同步数据源)
        /// </summary>
        public IList<SelectListItem> Options { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// select title attribute
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 动态异步数据源(来自JQ Tmpl)
        /// </summary>
        public string DataSource { get; set; } = "[]";
    }

    public class AppFormItemForCheckBoxWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; }

        public bool LabelInRight { get; set; }
    }

    public class AppFormItemForRadioButtonListWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 单选按钮组的类别名
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 是否横向显示
        /// </summary>
        public bool IsHorizontal { get; set; } = true;

        /// <summary>
        /// 单选按钮风格
        /// </summary>
        public WidgetStyle Style { get; set; } = WidgetStyle.Blue;

        /// <summary>
        /// 默认选中的值
        /// </summary>
        public string SelectedItemValue { get; set; }

        /// <summary>
        /// 单选按钮组的选项列表(同步数据源)
        /// </summary>
        public IList<SelectListItem> Items { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// 动态异步数据源(来自JQ Tmpl)
        /// </summary>
        public string DataSource { get; set; } = "[]";
    }

    public class AppFormItemForUploadAttachmentWrapper : AppFormComponentWrapper
    {
        public AppFormItemForUploadAttachmentWrapper()
        {
            this.IsBlockRow = true;
            this.DataRole = "attachment";
        }

        /// <summary>
        /// 上传完成处理的Url
        /// </summary>
        public string UploadUrl { get; set; }

        /// <summary>
        /// 下载文件的API地址
        /// </summary>
        public string DownloadUrl { get; set; }

        private string _DataUploadParams = string.Empty;

        /// <summary>
        /// 上传文件的参数
        /// </summary>
        public string DataUploadParams
        {
            get
            {
                string result = this._DataUploadParams;

                if (string.IsNullOrEmpty(this._DataUploadParams))
                {
                    if (string.IsNullOrEmpty(this.DataName) == false)
                        result = this.GetLastLevelDataName() + "Params";
                }

                return result;
            }
            set
            {
                this._DataUploadParams = value;
            }
        }

        /// <summary>
        /// 额外参数
        /// </summary>
        public string DataExtraFormData { get; set; } = "materialUploadModel";

        /// <summary>
        /// 最大上传的文件数
        /// </summary>
        public int MaxFileCount { get; set; } = 1;

        /// <summary>
        /// 上传的文件后缀列表
        /// </summary>
        public string Extensions { get; set; }

        /// <summary>
        /// 是否覆盖默认的文件后缀
        /// </summary>
        public bool Override { get; set; } = false;

        /// <summary>
        /// 提示语
        /// </summary>
        public string PlaceHolder { get; set; }

        private string _JsonData = string.Empty;

        /// <summary>
        /// 上传附件的Json数据
        /// </summary>
        public string JsonData
        {
            get
            {
                string result = this._JsonData;

                if (string.IsNullOrEmpty(this._JsonData))
                {
                    if (string.IsNullOrEmpty(this.DataName) == false)
                        result = this.GetLastLevelDataName() + "JsonData";
                }

                return result;
            }
            set
            {
                this._JsonData = value;
            }
        }
    }

    public class AppFormItemForCustomComponentWrapper : AppFormComponentWrapper
    {
        /// <summary>
        /// 自定义组件分布页路径
        /// </summary>
        public string CustomViewPath { get; set; }
    }

    #endregion

    #region Component Consts

    public class AppComponentConsts
    {
        // 文本常量
        public const string QueryCriteriaDefaultTitle = "快捷查询";
        public const string SelectPickerDefaultCaption = "请选择";
        public const string WorkflowNavigationTitle = "流程导航";
        public const string WorkflowDataFormTemplate = "表单模板";
        public const string WorkflowApprovalTitle = "流程审批";
        public const string UploadFileTitle = "上传文件";
        public const string DownloadFileTemplate = "下载模板";
        public const string SelectPickerDefaultSelectedValue = "";

        // 查询组件常量
        public const string QueryCriteriaContainer = "Components/Query/_QueryCriteriaContainer";
        public const string DataTableContainer = "Components/Query/_DataTableContainer";
        public const string TextBoxQueryItem = "Components/Query/_TextBoxQueryItem";
        public const string DatePickerQueryItem = "Components/Query/_DatePickerQueryItem";
        public const string DateTimePickerQueryItem = "Components/Query/_DateTimePickerQueryItem";
        public const string SelectPickerQueryItem = "Components/Query/_SelectPickerQueryItem";
        public const string SelectPickerExQueryItem = "Components/Query/_SelectPickerExQueryItem";
        // 表单组件常量
        public const string DataFormContainer = "Components/Form/_DataFormContainer";
        public const string DataFormSection = "Components/Form/_DataFormSection";
        public const string TextBoxFormItem = "Components/Form/_TextBoxFormItem";
        public const string TextAreaFormItem = "Components/Form/_TextAreaFormItem";
        public const string DatePickerFormItem = "Components/Form/_DatePickerFormItem";
        public const string DateTimePickerFormItem = "Components/Form/_DateTimePickerFormItem";
        public const string SelectPickerFormItem = "Components/Form/_SelectPickerFormItem";
        public const string SelectPickerExFormItem = "Components/Form/_SelectPickerExFormItem";
        public const string SelectUserPickerFormItem = "Components/Form/_SelectUserPickerFormItem";
        public const string SelectTagPickerFormItem = "Components/Form/_SelectTagPickerFormItem";
        public const string CheckBoxFormItem = "Components/Form/_CheckBoxFormItem";
        public const string RadioButtonListFormItem = "Components/Form/_RadioButtonListFormItem";
        public const string UploadAttachmentFormItem = "Components/Form/_UploadAttachmentFormItem";
        public const string CustomComponentFormItem = "Components/Form/_CustomComponentFormItem";
        // 工作流组件变量
        public const string WorkflowToolbar = "Components/Workflow/_WorkflowToolbar";
        public const string WorkflowProcesses = "Components/Workflow/_WorkflowProcesses";
        public const string WorkflowApproval = "Components/Workflow/_WorkflowApproval";
        public const string WorkflowSortedApproval = "Components/Workflow/_WorkflowSortedApproval";
    }

    #endregion

    #region Enumeration

    public enum FormItemDataType
    {
        None,
        Phone,
        Telephone,
        Mobile,
        Email,
        Number,
        Currency
    }

    #endregion
}