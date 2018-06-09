using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Common
{
    public class DataTransfer
    {
        public class DataTable
        { /// <summary>
          /// 整个查询语句结果的总条数，而非本DataTable的条数
          /// </summary>
            public int TotalCount { get; set; }
            public List<DataColumn> Columns { get; set; } = new List<DataColumn>();
            public List<DataRow> Rows { get; set; } = new List<DataRow>();
            public DataColumn[] PrimaryKey { get; set; }
            public DataRow NewRow()
            {
                return new DataRow(this.Columns, new object[Columns.Count]);
            }
        }
        public class DataColumn
        {
            public string ColumnName { get; set; }
            public Type ColumnType { get; set; }
            public DataColumn(string columnName, Type columnType)
            {
                this.ColumnName = columnName;
                this.ColumnType = columnType;
            }
        }
        public class DataRow
        {
            private object[] _ItemArray;
            public List<DataColumn> Columns { get; private set; }
            public DataRow(List<DataColumn> columns, object[] itemArray)
            {
                this.Columns = columns;
                this._ItemArray = itemArray;
            }
            public object this[int index]
            {
                get
                {
                    //如果传入的index不存在返回null
                    if (Columns.Count < index || index < 0)
                    {
                        return null;
                    }
                    return _ItemArray[index];
                }
                set { _ItemArray[index] = value; }
            }
            public object this[string columnName]
            {
                get
                {
                    int i = 0, n = 0;
                    foreach (DataColumn column in Columns)
                    {
                        if (column.ColumnName != columnName)
                        {
                            n++;
                        }
                        if (column.ColumnName == columnName)
                            break;
                        i++;
                    }
                    //如果传入的columnName不存在返回null
                    if (Columns.Count == i)
                    {
                        return null;
                    }
                    return _ItemArray[i];
                }
                set
                {
                    int i = 0;
                    foreach (DataColumn column in Columns)
                    {
                        if (column.ColumnName == columnName)
                            break;
                        i++;
                    }

                    _ItemArray[i] = value;
                }
            }
        }
    }
}
