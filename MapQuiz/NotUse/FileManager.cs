using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MapQuiz
{
    //public sealed class FileManager
    //{

    //    public static string ValueRecordFilePath
    //    {
    //        get
    //        {
    //            return System.Windows.Forms.Application.StartupPath + "\\Problem.Xml";
    //        }
    //    }

    //    public static ProblemModel LoadFromFile(string filePath)
    //    {
    //        if (!File.Exists(filePath)) return null;
    //        ProblemModel loadItem = null;
    //        XmlSerializer serializer = new XmlSerializer(typeof(ProblemModel));
    //        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    //        {
    //            try
    //            {
    //                loadItem = (ProblemModel)serializer.Deserialize(fs);
    //            }
    //            catch
    //            {
    //                loadItem = null;
    //            }
    //        }
    //        return loadItem;
    //    }

    //    public static ProblemModel LoadFromFile()
    //    {
    //        return LoadFromFile(ValueRecordFilePath);
    //    }

    //    public static bool SaveToFile(ProblemModel problemModel, string filePath)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(ProblemModel));
    //        bool res = true;
    //        try
    //        {
    //            using (FileStream fs = new FileStream(filePath, FileMode.Create))
    //            {
    //                serializer.Serialize(fs, problemModel);
    //            }
    //        }
    //        catch
    //        {
    //            res = false;
    //        }
    //        return res;
    //    }

    //    public static bool SaveToFile(ProblemModel problemModel)
    //    {
    //        return SaveToFile(problemModel, ValueRecordFilePath);
    //    }

    //}
}
