using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //گرفتن تمامی کلاس ها
            // var types = assembly.GetTypes();

            //برای گرفتن یک اتریبیوت خاص از دستور زیر استفاده میکنیم
            var types = assembly.GetTypes().Where(a => a.GetCustomAttributes<secondAttribute>().Any());

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);

                #region GetMembers
                //گرفتن یک ممبر با نام
                //var Prop = type.GetMember("prop0");

                //گرفتن پراپرتی ها  + ممبر ها + ممبر های کلاس پایه ابجکت  + کانستراکتور ها
                //var Props = type.GetMembers();
                #endregion GetMembers

                #region GetProperty
                //گرفتن پراپرتی های هر کلاس
                // var Props = type.GetProperties();
                #endregion GetProperty

                //برای گرفتن یک پرارپتی های خاص از دستور زیر استفاده میکنیم
                var Props = type.GetProperties().Where(t => t.GetCustomAttributes<memberAttribute>().Any());
                foreach (var prop in Props)
                {
                    Console.WriteLine("\t" + prop.Name);
                }
            }
            Console.ReadLine();
        }
    }

    #region Person Class

    [first]
    public class person
    {
        public int prop0 { get; set; }
        public int prop1 { get; set; }
        public int prop2 { get; set; }
        public int prop3 { get; set; }
    }

    #endregion Person Class


    #region Attributes
    //حتما باید این دیتا انوتیشن را وارد کنیم 
    //و جایی که میخواهیم این اتربیوت را استفاده کنیم را مشخص کنیم که مثلا اینجا کلاس است
    //اگر بیشتر از دو نوع تایپ داشتیم باید مقدار زیر را قرار دهیم
    //AllowMultiple = true

    [AttributeUsage(AttributeTargets.Class)]
    public class firstAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    public class secondAttribute : Attribute { }

    //در این قسمت ما فقط دسترسی به پراپرتی دادیم
    [AttributeUsage(AttributeTargets.Property)]
    public class memberAttribute : Attribute { }
    #endregion Attributes

}
