namespace Tensee.Banch
{
    /// <summary>
    /// 输入类型枚举
    /// </summary>
    public enum InputTypeEnum : byte
    {
        /// <summary>
        /// 下拉
        /// </summary>
        DropDown,

        /// <summary>
        /// 单选
        /// </summary>
        Radio,

        /// <summary>
        /// 多选
        /// </summary>
        Multi,

        /// <summary>
        /// 文本输入
        /// </summary>
        TextInput,
    }

    /// <summary>
    /// 值类型枚举
    /// </summary>
    public enum ValueTypeEnum : byte
    {
        Integer,
        Float,
        Bool,
        String,
        Byte,
        Long,       
        Double,
        Currency,
        DateTime,       
        /// <summary>
        /// Binary Large OBjects
        /// </summary>
        BLO,        
        List_Int,
        List_Float,
        List_String,
    }
}
