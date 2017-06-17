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
        [GCommand(isTranslated: true)]
        [GTranslation("{0}파일 열기", Locale.KO_KR)]
        [GTranslation("{0}ファイルを開く", Locale.JA_JP)]
        [GTranslation("Open file {0}", Locale.EN_US)]
        public static DataTable Load(string path)
        {
            return new CsvReader(path, true).ToTable();
        }

        [GCommand(isTranslated: true)]
        [GTranslation("{0}의 모든 공백 정리", Locale.KO_KR)]
        [GTranslation("{0}のすべてのスペースを削除", Locale.JA_JP)]
        [GTranslation("Clear all whitespace in {0}", Locale.EN_US)]
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
