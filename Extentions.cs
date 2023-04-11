public static class Extensions
{
    public const string null_msg = "item is null!";
    /// <summary>
    /// Check if items are contien item or not!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="items"></param>
    /// <returns></returns>    
    public static bool In<T>(this T item, params T[] items)
    {
        if (items == null) throw new ArgumentNullException(null_msg);
        return items.Contains(item);
    }
    /// <summary>
    /// Check if the item is null or not!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public static bool IsNull<T>(this T item){ return item == null; }
    /// <summary>
    /// Check if the item is number or not!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public static bool IsNumber<T>(this T item, params T[] items)
    {
        if (item.IsNull()) throw new ArgumentNullException(null_msg);
        return typeof(T).In(typeof(int), typeof(Int32), typeof(Int64));
    }
    /// <summary>
    /// Check if this DataSet or DataTable is Empty or Not !
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    public static bool IsEmpty<T>(this T item)
    {
        if (item.IsNull()) throw new ArgumentNullException(null_msg);
        bool isTable = item.IsTable();
        bool isSet = item.IsSet();
        return isSet ? (item as DataSet).Tables.Count == 0 || 
                        (item as DataSet).Tables[0].Rows.Count == 0 : 
                            isTable ? (item as DataTable).Rows.Count == 0 : false;
    }
    /// <summary>
    /// Check if the item is DataTable !
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    public static bool IsSet<T>(this T item)
    {
        if (item.IsNull()) throw new ArgumentNullException(null_msg);
        return typeof(T).In(typeof(DataSet));
    }
    /// <summary>
    /// Check if the item is DataTable !
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    public static bool IsTable<T>(this T item)
    {
        if (item.IsNull()) throw new ArgumentNullException(null_msg);
        return typeof(T).In(typeof(DataTable)) ;
    }
}