using Accord.IO;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Data;
using System.Linq;

namespace GSharp.Modules.Accord
{
    public class GAccord : GModule
    {
        [GCommand("{0}파일 열기")]
        [GTranslation("{0}ファイルを開く", Locale.JA_JP)]
        public static DataTable Load(string path)
        {
            return new CsvReader(path, true).ToTable();
        }

        [GCommand("{0}의 모든 공백 정리")]
        [GTranslation("{0}のすべてのスペースを削除", Locale.JA_JP)]
        public static void ClearNullDatas(DataTable data)
        {
            foreach (DataColumn dataColumn in data.Columns)
            {
                dataColumn.ReadOnly = false;
            }

            foreach (DataRow dataRow in data.Rows)
            {
                for (int i = 0; i < dataRow.ItemArray.Count(); i++)
                {
                    if (dataRow[i] is DBNull)
                    {
                        dataRow[i] = "NULL";
                    }
                }
            }
        }
    }
}
