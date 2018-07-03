namespace Tensee.Banch
{
    /// <summary>
    /// Some consts used in the application.
    /// </summary>
    public class AppConsts
    {
        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "gsKxGZ012HLL3MI5";

        public const int ResizedMaxProfilPictureBytesUserFriendlyValue = 1024;

        public const int MaxProfilPictureBytesUserFriendlyValue = 5;

        /// <summary>
        /// 反射拷贝值  父类值拷贝到子类对象
        /// </summary>
        /// <typeparam name="TParent">父类</typeparam>
        /// <typeparam name="TChild">子类</typeparam>
        /// <param name="parent">父类对象</param>
        /// <returns>子类对象</returns>
        public static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
        {
            TChild child = new TChild();
            var ParentType = typeof(TParent);
            var Properties = ParentType.GetProperties();
            foreach (var Propertie in Properties)
            {
                //循环遍历属性
                if (Propertie.CanRead && Propertie.CanWrite)
                {
                    //进行属性拷贝
                    Propertie.SetValue(child, Propertie.GetValue(parent, null), null);
                }
            }
            return child;
        }
    }
}
