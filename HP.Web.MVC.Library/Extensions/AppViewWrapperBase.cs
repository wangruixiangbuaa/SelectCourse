namespace System.Web.Mvc
{
    public abstract class AppViewWrapperBase
    {
        /// <summary>
        /// 组件或控件的唯一标识属性
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 组件或控件的角色
        /// </summary>
        public string DataRole { get; set; }

        /// <summary>
        /// 表单数据所属的作用域
        /// </summary>
        public string DataScope { get; set; }

        /// <summary>
        /// 组件或控件扩展样式
        /// </summary>
        public string CssClass { get; set; }
    }
}