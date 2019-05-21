namespace System.Web.Mvc
{
    #region SearchButton Widget

    public class AppSearchButtonWrapper : AppViewWrapperBase
    {
        public AppSearchButtonWrapper()
        {
            this.DataRole = "search";
        }

        /// <summary>
        /// 查询按钮文本
        /// </summary>
        public string Text { get; set; } = AppWidgetConsts.SearchButtonDefaultText;

        /// <summary>
        /// 是否独占一行
        /// </summary>
        public bool IsBlockRow { get; set; } = false;
    }

    #endregion

    #region Button Widget

    public class AppButtonWrapper : AppViewWrapperBase
    {
        public AppButtonWrapper()
        {
            if (this.Disabled)
            {
                this.DataItemId = "";
            }
        }

        /// <summary>
        /// 按钮文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 按钮图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 联动触发器
        /// </summary>
        public string Trigger { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 按钮风格
        /// </summary>
        public WidgetStyle Style { get; set; } = WidgetStyle.Default;

        /// <summary>
        /// 是否为超链接
        /// </summary>
        public bool IsLink { get; set; } = false;

        /// <summary>
        /// 按钮导航地址(默认不导航)
        /// </summary>
        public string Href { get; set; } = "javascript:void(0);";

        /// <summary>
        /// 按钮大小(xs, sm, lg)
        /// </summary>
        public WidgetSize Size { get; set; } = WidgetSize.None;

        /// <summary>
        /// 绑定对应数据行的Id
        /// </summary>
        public string DataItemId { get; set; } = "Id";

        /// <summary>
        /// 是否打开新页面(默认不打开)
        /// </summary>
        public bool IsOpenNew { get; set; } = false;

        /// <summary>
        /// 是否独占一行
        /// </summary>
        public bool IsBlockRow { get; set; } = false;

        /// <summary>
        /// 按钮是否用于工作流
        /// </summary>
        public bool IsWorkflow { get; set; } = false;

        /// <summary>
        /// 是否需要监控
        /// </summary>
        public bool IsObservable { get; set; } = true;

        /// <summary>
        /// 是否用于关闭对话框
        /// </summary>
        public bool IsDismiss { get; set; } = false;

        /// <summary>
        /// 当前按钮所属的对话框
        /// </summary>
        public string ModalContainer { get; set; }

        /// <summary>
        /// 工具提示
        /// </summary>
        public string Tooltip { get; set; }
    }

    #endregion

    #region CheckBox Widget

    public class AppCheckBoxWrapper : AppViewWrapperBase
    {
        /// <summary>
        /// 绑定当前行标识
        /// </summary>
        public string DataItemId { get; set; } = "Id";

        /// <summary>
        /// 是否配置为全选复选框
        /// </summary>
        public bool IsCheckAll { get; set; } = false;
    }

    #endregion

    #region Modal Widget

    public class AppModalWrapper : AppViewWrapperBase
    {
        /// <summary>
        /// 对话框大小
        /// </summary>
        public WidgetSize Size { get; set; } = WidgetSize.MD;

        /// <summary>
        /// 对话框风格
        /// </summary>
        public WidgetStyle Style { get; set; } = WidgetStyle.PaleGreen;

        /// <summary>
        /// 距离顶部的高度百分比
        /// </summary>
        public int TopPercent { get; set; }

        /// <summary>
        /// 最大高度
        /// </summary>
        public int MaxHeight { get; set; }

        /// <summary>
        /// 自定义宽度
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// 对话框距离左侧的百分比
        /// </summary>
        public int? LeftPercent { get; set; }

        /// <summary>
        /// 对话框标题文字图标
        /// </summary>
        public string HeaderIcon { get; set; }

        /// <summary>
        /// 对话框标题文字描述
        /// </summary>
        public string HeaderTitle { get; set; }

        /// <summary>
        /// 对话框标题必填项提示(主要是用于Form)
        /// </summary>
        public string HeaderRequiredTip { get; set; } = AppWidgetConsts.HeaderRequiredTip;

        /// <summary>
        /// 对话框是否可滚动
        /// </summary>
        public bool IsScrollable { get; set; } = false;

        /// <summary>
        /// 点击模态对话框的外部区域不会将其关闭
        /// </summary>
        public bool IsBackdrop { get; set; } = true;

        /// <summary>
        /// 按下Esc键不会关闭Modal
        /// </summary>
        public bool IsKeyword { get; set; } = false;

        /// <summary>
        /// 对话框是否处于查看模式
        /// </summary>
        public bool IsViewMode { get; set; } = false;

        /// <summary>
        /// 当新增其他按钮之后是否抹掉默认的按钮(“确认”和“取消”）
        /// </summary>
        public bool ShowDefaultButton { get; set; } = true;

        /// <summary>
        /// 只读模式下对某些属性的更改
        /// </summary>
        public bool IsEditableForViewMode { get; set; } = false;

        /// <summary>
        /// 对话框内容分部页面路径
        /// </summary>
        public string ContentViewPath { get; set; }

        /// <summary>
        /// 对话框底部分部页面路径
        /// </summary>
        public string FooterViewPath { get; set; }

        /// <summary>
        /// 确认按钮文本
        /// </summary>
        public string ConfirmButtonText { get; set; } = AppWidgetConsts.ConfirmButtonDefaultText;

        /// <summary>
        /// 取消按钮文本
        /// </summary>
        public string CancelButtonText { get; set; } = AppWidgetConsts.CancelButtonDefaultText;

        /// <summary>
        /// 关闭按钮文本
        /// </summary>
        public string CloseButtonText { get; set; } = AppWidgetConsts.CloseButtonDefaultText;
    }

    #endregion

    #region Widget Consts

    public class AppWidgetConsts
    {
        // 文本常量
        public const string SearchButtonDefaultText = "查询";
        public const string ConfirmButtonDefaultText = "确认";
        public const string CancelButtonDefaultText = "取消";
        public const string CloseButtonDefaultText = "关闭";
        public const string HeaderRequiredTip = "为必填项";

        // 控件常量
        public const string Button = "Widgets/_Button";
        public const string SearchButton = "Widgets/_SearchButton";
        public const string Checkbox = "Widgets/_Checkbox";
        public const string Modal = "Widgets/_Modal";
        public const string DataTable = "Widgets/_DataTable";
        public const string ScrollableDataTable = "Widgets/_ScrollableDataTable";
        public const string Pager = "Widgets/_DataPager";
    }

    #endregion

    #region Enumeration

    /// <summary>
    /// 控件风格
    /// </summary>
    public enum WidgetStyle
    {
        /// <summary>
        /// 暗灰色（默认）
        /// </summary>
        Default,
        /// <summary>
        /// 深蓝色（强调）
        /// </summary>
        Primary,
        /// <summary>
        /// 淡蓝色（提醒）
        /// </summary>
        Info,
        /// <summary>
        /// 深绿色（成功）
        /// </summary>
        Success,
        /// <summary>
        /// 深黄色（警告）
        /// </summary>
        Warning,
        /// <summary>
        /// 深红色（错误）
        /// </summary>
        Danger,
        /// <summary>
        /// 浅蓝色（提醒）
        /// </summary>
        Blue,
        /// <summary>
        /// 淡蓝色（提醒）
        /// </summary>
        Sky,
        /// <summary>
        /// 浅蓝色（提醒）
        /// </summary>
        Azure,
        /// <summary>
        /// 浅绿色（成功）
        /// </summary>
        PaleGreen,
        /// <summary>
        /// 浅黄色（警告）
        /// </summary>
        Yellow,
        /// <summary>
        /// 浅红色（错误）
        /// </summary>
        DarkOrange,
        /// <summary>
        /// 浅棕色（强调）
        /// </summary>
        Magenta,
        /// <summary>
        /// 深紫色（强调）
        /// </summary>
        Purple,
        /// <summary>
        /// 深棕色（强调）
        /// </summary>
        Maroon
    }

    /// <summary>
    /// 控件大小
    /// </summary>
    public enum WidgetSize
    {
        None,
        XS,
        SM,
        MD,
        LG,
        XL
    }

    #endregion
}