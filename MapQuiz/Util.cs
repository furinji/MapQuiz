using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MapQuiz
{
    public sealed class Util
    {

        public static Point ConvertToRelativePos(Point pos, Size rootSize)
        {
            double relativeX = pos.X / rootSize.Width;
            double relativeY = pos.Y / rootSize.Height;
            return new Point(relativeX, relativeY);
        }

        public static string GetImageFilePath(string fileName)
        {
            return System.Windows.Forms.Application.StartupPath + "\\Image\\" + fileName;
        }

        public static void ListExchangeAt<Type>(IList<Type> list, int idx1, int idx2)
        {
            var temp = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = temp;
        }

        public static string ConvertToRelativePath(string absolutePath)
        {
            Uri u1 = new Uri(System.Windows.Forms.Application.StartupPath);
            Uri u2 = new Uri(u1, absolutePath);
            string relativePath = u1.MakeRelativeUri(u2).ToString();
            //URLデコードして、'/'を'\'に変更する
            relativePath = System.Web.HttpUtility.UrlDecode(relativePath).Replace('/', '\\');
            return relativePath;
        }

        public static string ConvertToAbsolutePath(string relativePath)
        {
            Uri u1 = new Uri(System.Windows.Forms.Application.StartupPath);
            Uri u2 = new Uri(u1, relativePath);
            return u2.LocalPath;
        }

    }
}
